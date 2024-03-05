using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Models.DTOs.Security;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : BaseSecureController
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet("claims/lookup")]
        [FalconOneAuthorize(new string[] { "Admin" })]
        [ResourceIdentifier(ResourceIdentifier.Security.GET_SECURITY_CLAIMS_LOOKUP)]
        public async Task<IActionResult> GetSecurityClaims()
        {
            var response = await _securityService.GetTenantSecurityClaimsForLookup();

            return Ok(response);
        }

        [HttpGet("roles/lookup")]
        [FalconOneAuthorize(new string[] { "Admin" })]
        [ResourceIdentifier(ResourceIdentifier.Security.GET_SECURITY_ROLES_LOOKUP)]
        public async Task<IActionResult> GetSecurityRoles()
        {
            var response = await _securityService.GetTenantSecurityRolesForLookup();

            return Ok(response);
        }

        [HttpPost("hash-user-password")]
        [ResourceIdentifier(ResourceIdentifier.Security.HASH_USER_PASSWORD)]
        public async Task<IActionResult> HashPassword(HashPasswordForUserDto model)
        {
            var result = await _securityService.HashPasswordForUserAsync(model);

            return Ok(result);
        }
    }
}
