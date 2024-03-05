using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Models.DTOs.Account;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace FalconOne.API.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class AccountController : BaseAccountController
    {
        public AccountController(IAccountService accountService) : base(accountService) { }

        [HttpPost("signup")]
        [ResourceIdentifier(ResourceIdentifier.Account.NEW_USER_SIGNUP)]
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Signup(SignupRequestDto model)
        {
            var response = await _accountService.RegisterAsync(model);

            return Ok(response);
        }

        [HttpPost("login")]
        [EnableRateLimiting("Token")]
        [ResourceIdentifier(ResourceIdentifier.Account.LOGIN)]
        [ProducesResponseType(typeof(LoginRequestDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            var response = await _accountService.LoginAsync(model);

            return Ok(response);
        }


        [HttpPost("forgot-password")]
        [ResourceIdentifier(ResourceIdentifier.Account.FORGOT_PASSWORD)]
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
        [ResourceIdentifier(ResourceIdentifier.Account.RESET_PASSWORD)]
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
        [ResourceIdentifier(ResourceIdentifier.Account.REVOKE_REFRESH_TOKEN)]
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
        [ResourceIdentifier(ResourceIdentifier.Account.REFRESH_TOKEN)]
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
