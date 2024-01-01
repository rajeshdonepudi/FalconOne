﻿using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Models.DTOs;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;

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
            if (ModelState.IsValid)
            {
                var response = await _accountService.SignupNewUserAsync(model);

                return AppResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [EnableRateLimiting("Token")]
        [ResourceIdentifier(AppResourceCodes.Account.LOGIN)]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.LoginUserAsync(model);

                return AppResponse(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, response));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPost("forgot-password")]
        [ResourceIdentifier(AppResourceCodes.Account.FORGOT_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.ForgotPasswordAsync(model);

                return AppResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("reset-password")]
        [ResourceIdentifier(AppResourceCodes.Account.RESET_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.ResetPasswordAsync(model);

                return AppResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("revoke-refresh-token")]
        [ResourceIdentifier(AppResourceCodes.Account.REVOKE_REFRESH_TOKEN)]
        [AllowAnonymous]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshTokenRequestDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.RevokeRefreshTokenAsync(model.RefreshToken);

                return AppResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("refresh-token")]
        [ResourceIdentifier(AppResourceCodes.Account.REFRESH_TOKEN)]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.GetNewJWTByRefreshTokenAsync(model.RefreshToken);

                return AppResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("username-available")]
        public async Task<IActionResult> IsUserNameAvailable(string username)
        {
            var response = await _accountService.IsUserNameAvailable(username);

            return AppResponse(response);
        }
    }
}