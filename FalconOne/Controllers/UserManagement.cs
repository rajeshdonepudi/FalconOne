using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Constants;
using Utilities.DTOs;
using Utilities.Helpers;

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
                var result = await _accountService.AddUserToRoleAsync(model);

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
                var result = await _appClaimService.AddClaimToUserAsync(model);
                return ReturnResponse(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("all-users")]
        [AllowAnonymous]
        [UserAction(ResourceCodes.GET_USER)]
        public async Task<IActionResult> GetAllUsers(PageParams model)
        {
            var response = await _accountService.GetAllAsync(model);

            return ReturnResponse(response);
        }
    }
}
