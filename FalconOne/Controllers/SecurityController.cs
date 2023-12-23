using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : BaseController
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet("claims/lookup")]
        [FalconOneAuthorize(new string[] { "Admin" })]
        [ResourceIdentifier(AppResourceCodes.Security.GET_SECURITY_CLAIMS_LOOKUP)]
        public async Task<IActionResult> GetSecurityClaims()
        {
            FalconeOne.BLL.Helpers.ApiResponse response = await _securityService.GetTenantSecurityClaimsForLookup();

            return AppResponse(response);
        }

        [HttpGet("roles/lookup")]
        [FalconOneAuthorize(new string[] { "Admin" })]
        [ResourceIdentifier(AppResourceCodes.Security.GET_SECURITY_ROLES_LOOKUP)]
        public async Task<IActionResult> GetSecurityRoles()
        {
            FalconeOne.BLL.Helpers.ApiResponse response = await _securityService.GetTenantSecurityRolesForLookup();

            return AppResponse(response);
        }
    }
}
