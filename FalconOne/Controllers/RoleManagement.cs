using FalconeOne.BLL.Interfaces;
using FalconOne.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManagement : BaseController
    {
        private readonly IAppRoleService _appRoleService;
        private readonly IAppClaimService _appClaimService;

        public RoleManagement(IAppRoleService appRoleService, IAppClaimService appClaimService)
        {
            _appRoleService = appRoleService;
            _appClaimService = appClaimService;
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(UserRoleDto role)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse result = await _appRoleService.CreateRoleAsync(role);

                return ReturnResponse(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("add-claim-to-role")]
        public async Task<IActionResult> AddClaimToRole(AddClaimToRoleDto model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse result = await _appClaimService.AddClaimToRoleAsync(model);

                return ReturnResponse(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("roles")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _appRoleService.GetAllRolesAsync());
        }
    }
}
