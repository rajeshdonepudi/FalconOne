using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.API.Contracts;
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
        private readonly IAccountService _accountService;
        private readonly IAppClaimService _appClaimService;

        public UserManagement(IAccountService accountService, IAppClaimService appClaimService)
        {
            _accountService = accountService;
            _appClaimService = appClaimService;
        }

        [HttpPost("add-user-to-role")]
        public async Task<IActionResult> AddUserToRole(AddToRoleDTO model)
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
        public async Task<IActionResult> AddClaimToUser(AddClaimToUserDTO model)
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
    }
}
