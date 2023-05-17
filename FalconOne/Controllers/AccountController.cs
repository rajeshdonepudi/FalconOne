using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Constants;
using Utilities.DTOs;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
        
            _accountService = accountService;
        }

        [HttpPost("register-new-user")]
        [AllowAnonymous]
        [UserAction(ResourceCodes.USER_CREATE)]
        public async Task<IActionResult> Register(RegisterNewUserRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.CreateNewUserAsync(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [UserAction(ResourceCodes.LOGIN)]
        public async Task<IActionResult> Login(AuthenticateRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.AuthenticateUserAsync(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("get-user")]
        [UserAction(ResourceCodes.GET_USER)]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _accountService.GetByIdAsync(userId);

            return ReturnResponse(response);
        }

        [HttpPost("forgot-password")]
        [UserAction(ResourceCodes.FORGOT_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.ForgotPasswordAsync(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("reset-password")]
        [UserAction(ResourceCodes.RESET_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.ResetPasswordAsync(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("revoke-refresh-token")]
        [UserAction(ResourceCodes.REVOKE_REFRESH_TOKEN)]
        [AllowAnonymous]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshTokenRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.RevokeRefreshTokenAsync(model.RefreshToken);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("refresh-token")]
        [UserAction(ResourceCodes.REFRESH_TOKEN)]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.GetNewJWTByRefreshTokenAsync(model.RefreshToken);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("{userId}/email-confirmed/{value}")]
        [AllowAnonymous]
        [UserAction(ResourceCodes.AAC_UPDATE_EMAIL_CONFIRMED)]
        public async Task<IActionResult> UpdateEmailConfirmed(string userId, bool value)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.UpdateEmailConfirmed(userId, value);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
