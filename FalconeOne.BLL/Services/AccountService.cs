﻿using AutoMapper;
using FalconeOne.BLL.DTOs;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DLL.Entities;
using FalconOne.DLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class AccountService : BaseService, IAccountService
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<IdentityOptions> _optionsAccessor;

        /// <summary>
        /// The data protection purpose used for the reset password related methods.
        /// </summary>
        public const string ResetPasswordTokenPurpose = "ResetPassword";

        /// <summary>
        /// The data protection purpose used for the change phone number methods.
        /// </summary>
        public const string ChangePhoneNumberTokenPurpose = "ChangePhoneNumber";

        /// <summary>
        /// The data protection purpose used for the email confirmation related methods.
        /// </summary>
        public const string ConfirmEmailTokenPurpose = "EmailConfirmation";
        #endregion

        #region Constructor
        public AccountService(UserManager<User> userManager,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _optionsAccessor = optionsAccessor;
        }
        #endregion

        #region Implementation

        public async Task<ApiResponse> AuthenticateUserAsync(AuthenticateRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (!result.Succeeded)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.LOGIN_FAILED, model);
            }

            var jwtToken = await GenerateJWTToken(user);

            var refreshToken = await GenerateRefreshToken();

            await RemoveOldRefreshTokens(user);

            user.RefreshTokens.Add(refreshToken);

            await _userManager.UpdateAsync(user);

            var response = new AuthenticateResponseDTO
            {
                JWTToken = jwtToken,
                RefreshToken = refreshToken.Token
            };

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.LOGIN_SUCCESSFULL, response));
        }

        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status200OK)]
        public async Task<ApiResponse> CreateNewUserAsync(RegisterNewUserRequestDTO model)
        {
            var newUser = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(newUser, model.ConfirmPassword);

            if (!result.Succeeded)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.FAILED_TO_CREATE_USER, model, result.Errors);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.SOMETHING_WENT_WRONG);
            }
            var account = _mapper.Map<AccountDTO>(user);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.USER_CREATED_SUCCESSFULLY, account));
        }

        public async Task<ApiResponse> DeleteAsync(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.INVALID_USER_ID));
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.USER_DELETION_FAILED));
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.USER_DELETED_SUCCESSFULLY));
        }

        public async Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null) return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));

            var result = await _userManager.IsEmailConfirmedAsync(user);

            if (!result)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.PLEASE_CONFIRM_EMAIL, result));
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.FORGOT_PASSWORD_SUCCESS, resetToken));

        }
        public async Task<ApiResponse> GetAllAsync()
        {
            var result = new List<AccountDTO>();

            var users = await _userManager.Users.ToListAsync();

            if (!users.Any())
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.NO_USERS_FOUND));
            }

            foreach (var user in users)
            {
                var res = _mapper.Map<AccountDTO>(user);
                result.Add(res);
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
        public async Task<ApiResponse> GetByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.INVALID_USER_ID));
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            var result = _mapper.Map<AccountDTO>(user);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
        public Task<AuthenticateResponseDTO> GetNewJWTByRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
        public async Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequestDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            var result = await _userManager.ResetPasswordAsync(user, model.ResetToken, model.ConfirmNewPassword);

            if (!result.Succeeded)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.RESET_PASSWORD_FAILED, model);
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.RESET_PASSWORD_SUCESS, model));
        }

        public async Task<ApiResponse> RevokeRefreshTokenAsync(string refreshToken)
        {
            var token = await _userManager.Users.AsNoTracking().SelectMany(t => t.RefreshTokens).FirstOrDefaultAsync(t => t.Token == refreshToken);

            if (token is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.REFRESH_TOKEN_NOT_FOUND));
            }

            var account = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token == refreshToken));

            if (account is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            if (!token.IsActive)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.REFRESH_TOKEN_EXPIRED));
            }

            UpdateRefreshTokenSettings(token, string.Empty, MessageHelper.REFRESH_TOKEN_REVOKED, string.Empty);

            await _userManager.UpdateAsync(account);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }

        public Task<AuthenticateResponseDTO> UpdateUserAsync(int id, RegisterNewUserRequestDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> VerifyEmailAsync(VerifyEmailDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }
            var result = await _userManager.ConfirmEmailAsync(user, model.EmailConfirmationToken);

            if (!result.Succeeded)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.EMAIL_CONFIRM_FAILED, result.Errors));
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.EMAIL_CONFIRM_SUCCESS));
        }

        #endregion

        #region Private methods
        private async Task<string> GenerateJWTToken(User user)
        {
            var claims = await _userManager.GetClaimsAsync(user);

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.
                                                Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,
                                                when an unknown printer took a galley of type and scrambled it to make a type specimen book.
                                                It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.
                                                It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages,
                                                and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        private async Task<RefreshToken> GenerateRefreshToken()
        {
            var refreshToken = GetToken();

            var refreshTokens = await _userManager.Users.AsNoTracking().SelectMany(x => x.RefreshTokens).ToListAsync();

            if (refreshTokens.Any())
            {
                bool isUniqueToken = !refreshTokens.Any(t => t.Token == refreshToken.Token);

                if (!isUniqueToken)
                {
                    var newToken = await GenerateRefreshToken();
                    return await Task.FromResult(newToken);
                }
            }
            return await Task.FromResult(refreshToken);
        }
        private RefreshToken GetToken()
        {
            return new RefreshToken
            {
                Token = Convert.ToHexString(GetRandomBytes(64)),
                Expires = DateTime.UtcNow.AddMinutes(3),
                Created = DateTime.UtcNow,
                CreatedByIp = ""
            };
        }
        private byte[] GetRandomBytes(int length)
        {
            return RandomNumberGenerator.GetBytes(length);
        }
        private async Task RemoveOldRefreshTokens(User user)
        {
            int res = user.RefreshTokens.RemoveAll(x => !x.IsActive && x.Created.AddMinutes(3) <= DateTime.UtcNow);

            await _userManager.UpdateAsync(user);
        }
        private void UpdateRefreshTokenSettings(RefreshToken token, string ipAddress = "", string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }
        #endregion
    }
}
