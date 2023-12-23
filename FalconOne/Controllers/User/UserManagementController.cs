using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.DTOs.Users;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAppClaimService _appClaimService;

        public UserManagementController(IUserService accountService, IAppClaimService appClaimService)
        {
            _userService = accountService;
            _appClaimService = appClaimService;
        }

        [HttpGet("dashboard-info")]
        [AllowAnonymous]
        [ResourceIdentifier(AppResourceCodes.User.USER_MANAGMENT_DASHBOARD)]
        public async Task<IActionResult> Dashboard()
        {
            return AppResponse(await _userService.GetDashboardInfo());
        }

        [HttpPost("add-user-to-role")]
        public async Task<IActionResult> AddUserToRole(AddToRoleDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AddUserToRoleAsync(model);

                return AppResponse(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("add-user")]
        [ResourceIdentifier(AppResourceCodes.User.ADD_NEW_USER)]
        public async Task<IActionResult> AddUser(AddUserDto model)
        {
            var result = await _userService.AddUser(model);

            return AppResponse(result);
        }

        [HttpPost("add-claim-to-user")]
        public async Task<IActionResult> AddClaimToUser(AddClaimToUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _appClaimService.AddClaimToUserAsync(model);
                return AppResponse(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("all-users")]
        [AllowAnonymous]
        [ResourceIdentifier(AppResourceCodes.Account.GET_USER)]
        public async Task<IActionResult> GetAllUsers(PageParams model)
        {
            var response = await _userService.GetAllAsync(model);

            return AppResponse(response);
        }

        [HttpGet("get-user")]
        [ResourceIdentifier(AppResourceCodes.Account.GET_USER)]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _userService.GetByIdAsync(userId);

            return AppResponse(response);
        }

        [HttpPatch("{userId}/email-confirmed/{value}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateEmailConfirmed(string userId, bool value)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.UpdateEmailConfirmed(userId, value);

                return AppResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
