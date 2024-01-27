using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Models.DTOs;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace FalconOne.API.Controllers.Account
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

        [HttpPost("signup")]
        [AllowAnonymous]
        [ResourceIdentifier(AppResourceCodes.Account.NEW_USER_SIGNUP)]
        public async Task<IActionResult> Signup(SignupRequestDto model)
        {
            var response = await _accountService.RegisterAsync(model);

            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [EnableRateLimiting("Token")]
        [ResourceIdentifier(AppResourceCodes.Account.LOGIN)]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            var response = await _accountService.LoginAsync(model);

            return Ok(response);
        }


        [HttpPost("forgot-password")]
        [ResourceIdentifier(AppResourceCodes.Account.FORGOT_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestDto model)
        {
            var response = await _accountService.SendForgotPasswordResetTokenAsync(model);

            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("reset-password")]
        [ResourceIdentifier(AppResourceCodes.Account.RESET_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDto model)
        {
            var response = await _accountService.ResetPasswordAsync(model);

            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("revoke-refresh-token")]
        [ResourceIdentifier(AppResourceCodes.Account.REVOKE_REFRESH_TOKEN)]
        [AllowAnonymous]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshTokenRequestDto model)
        {
            var response = await _accountService.RevokeRefreshTokenAsync(model.RefreshToken);

            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("refresh-token")]
        [ResourceIdentifier(AppResourceCodes.Account.REFRESH_TOKEN)]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto model)
        {
            var response = await _accountService.GetJWTByRefreshTokenAsync(model.RefreshToken);

            return BadRequest(response);
        }

        [HttpPost("username-available")]
        public async Task<IActionResult> IsUserNameAvailable(string username)
        {
            var response = await _accountService.IsUserNameAvailable(username);

            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
