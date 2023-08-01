using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class SecurityService : BaseService, ISecurityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IAppConfigService _appConfigService;

        public SecurityService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            SignInManager<User> signInManager,
            ITenantService tenantService,
            ITokenService tokenService,
            IAppConfigService appConfigService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _appConfigService = appConfigService;
        }

        public async Task<ApiResponse> GetTenantSecurityClaimsForLookup()
        {
            var result = await _unitOfWork.SecurityClaimsRepository.GetTenantSecurityClaimsForLookup(await _tenantService.GetTenantId(), CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }

        public async Task<ApiResponse> GetTenantSecurityRolesForLookup()
        {
            var result = await _unitOfWork.SecurityRolesRepository.GetTenantSecurityRolesForLookup(await _tenantService.GetTenantId(), CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
    }
}
