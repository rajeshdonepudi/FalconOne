﻿using FalconeOne.BLL.Interfaces;
using FalconOne.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("get-all-policies")]
        public async Task<IActionResult> GetAllPolicies()
        {
            var response = await _appPolicyService.GetAllPolicies();

            return ReturnResponse(response);
        }

        [HttpDelete("delete-policy")]
        public async Task<IActionResult> DeletePolicy(Guid policyId)
        {
            var response = await _appPolicyService.DeletePolicy(policyId);

            return ReturnResponse(response);
        }
    }
}
