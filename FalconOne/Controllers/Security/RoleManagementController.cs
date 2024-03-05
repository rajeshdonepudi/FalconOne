using FalconeOne.BLL.Interfaces;
using FalconOne.Models.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManagementController : BaseSecureController
    {
        private readonly IAppRoleService _appRoleService;

        public RoleManagementController(IAppRoleService appRoleService)
        {
            _appRoleService = appRoleService;
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

        [HttpGet("roles")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _appRoleService.GetAllRolesAsync());
        }
    }
}
