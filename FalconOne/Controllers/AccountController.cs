﻿using FalconOne.API.Attributes;
using FalconOne.API.Contracts;
using FalconOne.Models.DTOs;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        [UserAction(AppResourceCodes.Account.REGISTER_NEW_USER)]
        public async Task<IActionResult> Register(RegisterNewUserRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.CreateNewUserAsync(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [UserAction(AppResourceCodes.Account.LOGIN)]
        public async Task<IActionResult> Login(AuthenticateRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.AuthenticateUserAsync(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("get-user")]
        [UserAction(AppResourceCodes.Account.GET_USER)]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.GetByIdAsync(userId);

            return ReturnResponse(response);
        }

        [HttpPost("forgot-password")]
        [UserAction(AppResourceCodes.Account.FORGOT_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.ForgotPasswordAsync(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("reset-password")]
        [UserAction(AppResourceCodes.Account.RESET_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.ResetPasswordAsync(model);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("revoke-refresh-token")]
        [UserAction(AppResourceCodes.Account.REVOKE_REFRESH_TOKEN)]
        [AllowAnonymous]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshTokenRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.RevokeRefreshTokenAsync(model.RefreshToken);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("refresh-token")]
        [UserAction(AppResourceCodes.Account.REFRESH_TOKEN)]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse response = await _accountService.GetNewJWTByRefreshTokenAsync(model.RefreshToken);

                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
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
