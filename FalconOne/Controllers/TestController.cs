using FalconOne.API.Attributes;
using FalconOne.Security;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : BaseSecureController
    {
        [HttpGet("test")]
        [ResourceIdentifier(ResourceCodes.ResourceIdentifier.Account.LOGIN)]
        [ApiAuthorize(SecurityPolicies.TENANT_ADMIN_POLICY)]
        public async Task<IActionResult> Get()
        {
            return Ok("Test verification successfull.");
        }
    }
}
