using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Utilities.DTOs;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyManagementController : BaseController
    {
        private readonly IAppPolicyService _appPolicyService;

        public PolicyManagementController(IAppPolicyService appPolicyService)
        {
            _appPolicyService = appPolicyService;
        }

        [HttpPost("create-new-policy")]
        public async Task<IActionResult> CreatePolicy(CreatePolicyDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _appPolicyService.CreatePolicy(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
