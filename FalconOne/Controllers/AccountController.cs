using FalconeOne.BLL.DTOs;
using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Register(RegisterNewUserRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.CreateNewUserAsync(model);
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticateRequestDTO model)
        {
            var response = await _accountService.AuthenticateUserAsync(model);

            //AddResponseHeader("RefreshToken", response.Data.RefreshToken);
            //var result = JsonConvert.SerializeObject(response);
            return ReturnResponse(response);
        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _accountService.GetAllAsync();
            return ReturnResponse(response);
        }

        [HttpGet("get-user")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _accountService.GetByIdAsync(userId);
            return ReturnResponse(response);
        }

        [HttpPost("forgot-password")]
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
    }
}
