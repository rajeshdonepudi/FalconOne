using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Utilities.DTOs;

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
    }
}
