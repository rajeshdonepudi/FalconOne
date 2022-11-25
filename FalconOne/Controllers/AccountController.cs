using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Utilities.DTOs;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IAppRoleService _appRoleService;

        public AccountController(IAccountService accountService, IAppRoleService appRoleService)
        {
            _accountService = accountService;
            _appRoleService = appRoleService;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
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

        [HttpPost("refresh-token")]
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
    }
}
