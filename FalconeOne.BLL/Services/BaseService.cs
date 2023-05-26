using FalconOne.DAL.Interfaces;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FalconeOne.BLL.Services
{
    public class BaseService
    {
        protected readonly UserManager<User> _userManager;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(UserManager<User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> GetCurrentTenantId()
        {

            if (_httpContextAccessor.HttpContext.User.Identities.Any())
            {
                var tenant = _httpContextAccessor?.HttpContext?.User?.Identities?
                                                    .SelectMany(x => x.Claims)
                                                    .FirstOrDefault(x => x.Type == "TenantId");

                var user = _httpContextAccessor?.HttpContext?.User?.Identities?
                                                    .SelectMany(x => x.Claims)
                                                    .FirstOrDefault(x => x.Type == "UserId");

                if (!string.IsNullOrEmpty(tenant.Value) && !string.IsNullOrEmpty(user.Value))
                {
                    Guid.TryParse(tenant.Value, out var tenantId);
                    Guid.TryParse(user.Value, out var userId);

                    var result = await IsValidTenant(tenantId, userId);

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
            var tenant = await _unitOfWork.TenantRepository.FindAsync(tenantId);

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is not null && tenant is not null)
            {
                var result = (user).TenantId == tenant.Id;

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
