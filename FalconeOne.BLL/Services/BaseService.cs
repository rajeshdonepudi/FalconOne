using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FalconeOne.BLL.Services
{
    public class BaseService
    {
        protected readonly UserManager<User> _userManager;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IConfiguration _configuration;
        protected readonly ITenantService _tenantService;

        public BaseService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, ITenantService tenantService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _tenantService = tenantService;
        }

        public async Task<Guid> GetCurrentTenantId()
        {

            if (_httpContextAccessor.HttpContext.User.Identities.Any())
            {
                System.Security.Claims.Claim? tenant = _httpContextAccessor?.HttpContext?.User?.Identities?
                                                    .SelectMany(x => x.Claims)
                                                    .FirstOrDefault(x => x.Type == "TenantId");

                System.Security.Claims.Claim? user = _httpContextAccessor?.HttpContext?.User?.Identities?
                                                    .SelectMany(x => x.Claims)
                                                    .FirstOrDefault(x => x.Type == "UserId");

                if (!string.IsNullOrEmpty(tenant.Value) && !string.IsNullOrEmpty(user.Value))
                {
                    Guid.TryParse(tenant.Value, out Guid tenantId);
                    Guid.TryParse(user.Value, out Guid userId);

                    bool result = await IsValidTenant(tenantId, userId);

                    if (result)
                    {
                        return tenantId;
                    }
                    throw new Exception("Validation failed");
                }
            }
            throw new ArgumentNullException("Invalid token or token not found.");
        }

        protected List<BusinessError> PrepareErrors(IEnumerable<IdentityError> identityErrors)
        {
            return identityErrors.Select(x => new BusinessError { Code = x.Code, Description = x.Description }).ToList();
        }

        private async Task<bool> IsValidTenant(Guid tenantId, Guid userId)
        {
            Tenant? tenant = await _unitOfWork.TenantRepository.GetByIdAsync(tenantId, CancellationToken.None);

            User? user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is not null && tenant is not null)
            {
                bool result = user.Tenants.Any(x => x.TenantId == tenant.Id);

                if (!result)
                {
                    throw new Exception("Unauthorized");
                }

                return result;
            }
            else
            {
                throw new Exception("Invalid request.");
            }
        }
    }
}
