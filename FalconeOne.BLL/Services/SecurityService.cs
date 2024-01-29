using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FalconeOne.BLL.Services
{
    public class SecurityService : BaseService, ISecurityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IAppConfigService _appConfigService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public SecurityService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            SignInManager<User> signInManager,
            ITenantService tenantService,
            ITokenService tokenService,
            IAppConfigService appConfigService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, IPasswordHasher<User> passwordHasher) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _appConfigService = appConfigService;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityClaimsForLookup()
        {
            var result = await _unitOfWork.SecurityClaimsRepository.GetTenantSecurityClaimsForLookup(await _tenantService.GetTenantId(), CancellationToken.None);

            return result;
        }

        public async Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityRolesForLookup()
        {
            var result = await _unitOfWork.SecurityRolesRepository.GetTenantSecurityRolesForLookup(await _tenantService.GetTenantId(), CancellationToken.None);

            return result;
        }

        public async Task<string> HashPasswordForUserAsync(HashPasswordForUserDto model)
        {
            if(model is null || model.UserId is null || model.UserId is null)
            {
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);

            if(user is null)
            {
                throw new ApiException(MessageHelper.SOMETHING_WENT_WRONG);
            }

            var hashedPassword = await Task.FromResult(_passwordHasher.HashPassword(user, model.Password));

            return hashedPassword;
        }
    }
}
