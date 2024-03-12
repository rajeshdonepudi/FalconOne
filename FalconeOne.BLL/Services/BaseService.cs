using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class BaseService
    {
        protected readonly UserManager<User> _userManager;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IConfiguration _configuration;
        protected readonly ITenantProvider _tenantService;

        public BaseService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, ITenantProvider tenantService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _tenantService = tenantService;
        }

        protected string GetClientIPAddress()
        {
            string ipAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString()!;

            if (IPAddress.TryParse(ipAddress, out var parsedAddress))
            {
                if (parsedAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    ipAddress = parsedAddress.MapToIPv4().ToString();
                }
            }

            return ipAddress;
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

        protected string FormatIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            return string.Join(',', identityErrors.Select(x => x.Description).ToArray());
        }

        protected static bool IsBase64Encoded(string input)
        {
            try
            {
                byte[] buffer = Convert.FromBase64String(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        protected static string ConvertToBase64(string text)
        {
            string base64String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));

            return base64String;
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

        protected async Task EmailVerificationCheck(User user)
        {
            bool isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            if (!isEmailConfirmed)
            {
                throw new ApiException(ErrorMessages.PLEASE_CONFIRM_EMAIL);
            }
        }
    }
}
