
using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : BaseSecureController
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService accountService)
        {
            _userService = accountService;
        }

        [HttpGet("dashboard-info")]
        [AllowAnonymous]
        [ResourceIdentifier(ResourceIdentifier.User.USER_MANAGMENT_DASHBOARD)]
        public async Task<IActionResult> Dashboard()
        {
            var result = await _userService.GetDashboardInfo();

            return Ok(result);
        }

        [HttpPost("add-user-to-role")]
        public async Task<IActionResult> AddUserToRole(AddToRoleDto model)
        {
            var result = await _userService.AddUserToRoleAsync(model);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add-user")]
        [ResourceIdentifier(ResourceIdentifier.User.ADD_NEW_USER)]
        public async Task<IActionResult> AddUser(AddUserDto model)
        {
            var result = await _userService.AddUser(model);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("all-users")]
        [AllowAnonymous]
        [ResourceIdentifier(ResourceIdentifier.Account.GET_USER)]
        public async Task<IActionResult> GetAllUsers(PageParams model)
        {
            var response = await _userService.GetAllAsync(model);

            return Ok(response);
        }

        [HttpGet("get-user")]
        [ResourceIdentifier(ResourceIdentifier.Account.GET_USER)]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _userService.GetByIdAsync(userId);

            return Ok(response);
        }
    }
}
