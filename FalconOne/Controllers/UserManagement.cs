﻿using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.DTOs.Users;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagement : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAppClaimService _appClaimService;

        public UserManagement(IUserService accountService, IAppClaimService appClaimService)
        {
            _userService = accountService;
            _appClaimService = appClaimService;
        }

        [HttpGet("dashboard-info")]
        [AllowAnonymous]
        [ResourceIdentifier(AppResourceCodes.User.USER_MANAGMENT_DASHBOARD)]
        public async Task<IActionResult> Dashboard()
        {
            return ReturnResponse(await _userService.GetDashboardInfo());
        }

        [HttpPost("add-user-to-role")]
        public async Task<IActionResult> AddUserToRole(AddToRoleDto model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse result = await _userService.AddUserToRoleAsync(model);

                return ReturnResponse(result);
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
            FalconeOne.BLL.Helpers.ApiResponse result = await _userService.AddUser(model);

            return ReturnResponse(result);
        }

        [HttpPost("add-claim-to-user")]
        public async Task<IActionResult> AddClaimToUser(AddClaimToUserDto model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse result = await _appClaimService.AddClaimToUserAsync(model);
                return ReturnResponse(result);
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
            FalconeOne.BLL.Helpers.ApiResponse response = await _userService.GetAllAsync(model);

            return ReturnResponse(response);
        }

        [HttpGet("get-user")]
        [ResourceIdentifier(AppResourceCodes.Account.GET_USER)]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            FalconeOne.BLL.Helpers.ApiResponse response = await _userService.GetByIdAsync(userId);

            return ReturnResponse(response);
        }

        [HttpPatch("{userId}/email-confirmed/{value}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateEmailConfirmed(string userId, bool value)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse response = await _userService.UpdateEmailConfirmed(userId, value);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
