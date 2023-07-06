using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Extensions.Http;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FalconeOne.BLL.Services
{
    public class AccountService : BaseService, IAccountService
    {
        #region Fields
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IAppConfigService _appConfigService;

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
            IUnitOfWork unitOfWork,
            SignInManager<User> signInManager,
            ITenantService tenantService,
            ITokenService tokenService,
            IAppConfigService appConfigService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _appConfigService = appConfigService;
        }
        #endregion

        #region Implementation

        public async Task<ApiResponse> LoginUserAsync(LoginRequestDto model)
        {
            User? user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND);
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (!result.Succeeded)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.LOGIN_FAILED, model);
            }

            string jwtToken = await GenerateJWTToken(user);

            RefreshToken? refreshToken = await GenerateRefreshToken();

            await RemoveExpiredRefreshTokens(user);

            user.RefreshTokens.Add(refreshToken);

            await _userManager.UpdateAsync(user);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            AuthenticateResponseDto authResponse = new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                JWTToken = jwtToken,
                RefreshToken = refreshToken?.Token,
                TenantId = await _tenantService.GetTenantId()
            };

            authResponse.JWTToken = jwtToken;

            authResponse.RefreshToken = refreshToken.Token!;

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.LOGIN_SUCCESSFULL, authResponse));
        }

        public async Task<ApiResponse> SignupNewUserAsync(SignupRequestDto model)
        {
            User newUser = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
            };

            newUser.CreatedOn = DateTime.UtcNow;

            IdentityResult result = await _userManager.CreateAsync(newUser, model.ConfirmPassword);

            if (!result.Succeeded)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.FAILED_TO_CREATE_USER, model, result.Errors);
            }

            User? user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.SOMETHING_WENT_WRONG);
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.USER_CREATED_SUCCESSFULLY, new RegisterResponse(user.FirstName, user.LastName, user.Email)));
        }

        public async Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequestDto model)
        {
            User? user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null) return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));

            bool result = await _userManager.IsEmailConfirmedAsync(user);

            if (!result)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.PLEASE_CONFIRM_EMAIL, result));
            }

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.FORGOT_PASSWORD_SUCCESS, resetToken));
        }


        public async Task<ApiResponse> GetNewJWTByRefreshTokenAsync(string refreshToken)
        {
            User? account = await _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token == refreshToken));

            if (account is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.INVALID_REFRESH_TOKEN));
            }

            RefreshToken? token = account.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken);

            if (token!.IsRevoked)
            {
                await RevokeDescendantRefreshTokens(token, account, "", MessageHelper.REUSE_OF_REVOKED_ANCESTOR_TOKEN);

                IdentityResult updateResult = await _userManager.UpdateAsync(account);

                return await Task.FromResult(new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.SOMETHING_WENT_WRONG));
            }

            RefreshToken newRefreshToken = await RotateRefreshToken(token, "");

            account.RefreshTokens.Add(newRefreshToken);

            await RemoveExpiredRefreshTokens(account);

            IdentityResult result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.SOMETHING_WENT_WRONG));
            }

            string jwtToken = await GenerateJWTToken(account);

            AuthenticateResponseDto response = new()
            {
                JWTToken = jwtToken,
                RefreshToken = newRefreshToken.Token
            };

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, response));
        }
        public async Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequestDto model)
        {
            User? user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(user, model.ResetToken, model.ConfirmNewPassword);

            if (!result.Succeeded)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.RESET_PASSWORD_FAILED, model);
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.RESET_PASSWORD_SUCESS, model));
        }

        public async Task<ApiResponse> RevokeRefreshTokenAsync(string refreshToken)
        {
            User? account = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token == refreshToken));

            RefreshToken? token = account.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken);

            if (account is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.INVALID_REFRESH_TOKEN));
            }

            if (!token.IsActive)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.REFRESH_TOKEN_EXPIRED));
            }

            UpdateRefreshTokenSettings(token, string.Empty, MessageHelper.REFRESH_TOKEN_REVOKED, string.Empty);

            await _userManager.UpdateAsync(account);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> ConfirmEmailAsync(ConfirmEmailRequestDto model)
        {
            User? user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, model.EmailConfirmationToken);

            if (!result.Succeeded)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.EMAIL_CONFIRM_FAILED, result.Errors));
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.EMAIL_CONFIRM_SUCCESS));
        }

        public async Task<ApiResponse> UpdateEmailConfirmed(string userId, bool value)
        {
            User? user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            user.EmailConfirmed = value;

            await _userManager.UpdateAsync(user);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> IsUserNameAvailable(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                Task<bool> result = _unitOfWork.UserRepository.IsUserNameAvailable(username);

                return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, new { UserNameAvailable = result }));
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.INVALID_REQUEST, new { UserNameAvailable = false }));
        }

        #endregion

        #region Private methods
        private async Task<string> GenerateJWTToken(User user)
        {
            IList<Claim> claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim("TenantId", (await _tenantService.GetTenantId()).ToString()));

            claims.Add(new Claim("UserId", user.Id.ToString()));

            string token = await _tokenService.GenerateJWTToken(user, claims);

            return await Task.FromResult(token);
        }
        private async Task<RefreshToken> GenerateRefreshToken()
        {
            RefreshToken refreshToken = await GetRefreshToken();

            List<RefreshToken> refreshTokens = await _userManager.Users.AsNoTracking().SelectMany(x => x.RefreshTokens).ToListAsync();

            if (refreshTokens.Any())
            {
                bool isUniqueToken = !refreshTokens.Any(t => t.Token == refreshToken.Token);

                if (!isUniqueToken)
                {
                    RefreshToken newToken = await GenerateRefreshToken();
                    return await Task.FromResult(newToken);
                }
            }
            return await Task.FromResult(refreshToken);
        }
        private async Task<RefreshToken> GetRefreshToken()
        {
            return await Task.FromResult(new RefreshToken
            {
                Token = Convert.ToHexString(GetRandomBytes(64)),
                Expires = DateTime.UtcNow.AddDays(double.Parse(await _appConfigService.GetValue("JWT:RefreshTokenValidity"))),
                Created = DateTime.UtcNow,
                CreatedByIp = _httpContextAccessor.HttpContext.GetRequestIP(true)
            });
        }
        private byte[] GetRandomBytes(int length)
        {
            return RandomNumberGenerator.GetBytes(length);
        }
        private async Task RemoveExpiredRefreshTokens(User user)
        {
            double expiry = double.Parse(await _appConfigService.GetValue("JWT:RefreshTokenValidity"));

            RefreshToken? lastRefreshToken = user.RefreshTokens.LastOrDefault();

            int res = user.RefreshTokens.RemoveAll(x => x.Id != lastRefreshToken!.Id && !x.IsActive && x.Created.AddMinutes(expiry) <= DateTime.UtcNow);

            await _userManager.UpdateAsync(user);
        }
        private async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ipAddress, string reason)
        {
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                RefreshToken? childRefreshToken = user.RefreshTokens.SingleOrDefault(t => t.Token == refreshToken.ReplacedByToken);

                if (childRefreshToken is not null)
                {
                    if (childRefreshToken.IsActive)
                    {
                        UpdateRefreshTokenSettings(childRefreshToken);
                    }
                    else
                    {
                        await RevokeDescendantRefreshTokens(childRefreshToken, user, ipAddress, reason);
                    }
                }
            }
        }
        private void UpdateRefreshTokenSettings(RefreshToken token, string ipAddress = "", string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }
        private async Task<RefreshToken> RotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            RefreshToken newRefreshToken = await GenerateRefreshToken();
            UpdateRefreshTokenSettings(refreshToken, ipAddress, MessageHelper.REPLACED_WITH_NEW_TOKEN, newRefreshToken.Token!);
            return newRefreshToken;
        }

        private void ValidateUserSignupInfo(SignupRequestDto info)
        {

        }
        #endregion
    }
}
