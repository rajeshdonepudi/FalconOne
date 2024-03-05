using FalconOne.API.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseSecureController
    {
        [HttpGet]
        [FalconOneAuthorize([Policies.Test.TEST_GET])]
        [ResourceIdentifier(ResourceCodes.ResourceIdentifier.Account.LOGIN)]
        public async Task<IActionResult> Get()
        {
            return Ok("Test verification successfull.");
        }
    }
}
