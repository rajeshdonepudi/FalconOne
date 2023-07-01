using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagement : BaseController
    {
        private readonly IUserService _accountService;
        private readonly IAppClaimService _appClaimService;

        public UserManagement(IUserService accountService, IAppClaimService appClaimService)
        {
            _accountService = accountService;
            _appClaimService = appClaimService;
        }

        [HttpPost("add-user-to-role")]
        public async Task<IActionResult> AddUserToRole(AddToRoleDto model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse result = await _accountService.AddUserToRoleAsync(model);

                return ReturnResponse(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
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
            FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.GetAllAsync(model);

            return ReturnResponse(response);
        }

        [HttpGet("get-user")]
        [ResourceIdentifier(AppResourceCodes.Account.GET_USER)]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.GetByIdAsync(userId);

            return ReturnResponse(response);
        }

        [HttpPatch("{userId}/email-confirmed/{value}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateEmailConfirmed(string userId, bool value)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.UpdateEmailConfirmed(userId, value);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
