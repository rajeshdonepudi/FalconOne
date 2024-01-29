using FalconeOne.BLL.Interfaces;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManagementController : BaseController
    {
        private readonly IAppRoleService _appRoleService;
        private readonly IAppClaimService _appClaimService;

        public RoleManagementController(IAppRoleService appRoleService, IAppClaimService appClaimService)
        {
            _appRoleService = appRoleService;
            _appClaimService = appClaimService;
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(UserRoleDto role)
        {
            var result = await _appRoleService.CreateRoleAsync(role);

            if (result)
            {
                return Created(GetRequestURI(), role);
            }
            return BadRequest();
        }

        [HttpPost("add-claim-to-role")]
        public async Task<IActionResult> AddClaimToRole(AddClaimToRoleDto model)
        {
            var result = await _appClaimService.AddClaimToRoleAsync(model);

            if (result)
            {
                return Created(GetRequestURI(), model);
            }
            return BadRequest();
        }

        [HttpGet("roles")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _appRoleService.GetAllRolesAsync());
        }
    }
}
