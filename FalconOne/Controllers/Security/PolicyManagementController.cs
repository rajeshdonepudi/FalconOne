using FalconeOne.BLL.Interfaces;
using FalconOne.Models.DTOs.Security;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.Security
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
        public async Task<IActionResult> CreatePolicy(CreatePolicyDto model)
        {
            var response = await _appPolicyService.CreatePolicy(model);

            if (response)
            {
                return Created(GetRequestURI(), model);
            }
            return BadRequest(response);
        }

        [HttpGet("get-all-policies")]
        public async Task<IActionResult> GetAllPolicies()
        {
            var response = await _appPolicyService.GetAllPolicies();

            return Ok(response);
        }

        [HttpDelete("delete-policy")]
        public async Task<IActionResult> DeletePolicy(Guid policyId)
        {
            var response = await _appPolicyService.DeletePolicy(policyId);

            if (response)
            {
                return Accepted();
            }
            return BadRequest();
        }
    }
}
