using FalconeOne.BLL.Interfaces;
using FalconOne.Models.DTOs.Users;
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

        [HttpGet("get-role")]
        public async Task<IActionResult> GetRole([FromQuery] string roleId)
        {
            var result = await _securityService.GetRoleAsync(roleId);

            return Ok(result);
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(UserRoleDto model)
        {
            var result = await _securityService.CreateRoleAsync(model);

            if (result) return Ok(result);

            return BadRequest();
        }

        [HttpDelete("delete-role")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var result = await _securityService.DeleteRoleAsync(roleId);

            if (result) return Ok();

            return BadRequest();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _securityService.GetAllRolesAsync();

            return Ok(result);
        }
    }
}
