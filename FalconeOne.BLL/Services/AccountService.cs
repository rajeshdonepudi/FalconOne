using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Account;
using FalconOne.Models.Entities;
using IdenticonSharp.Helpers;
using IdenticonSharp.Identicons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IIdenticonProvider _identiconProvider;

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
            IConfiguration configuration, IIdenticonProvider identiconProvider) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _appConfigService = appConfigService;
            _identiconProvider = identiconProvider;
        }
        #endregion

        #region Implementation

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto model)
        {
            User? user = await _unitOfWork.UserRepository
                                          .GetTenantUserInfoByEmail(await _tenantService.GetTenantId(), model.Email, CancellationToken.None);

            if (user is null)
            {
                throw new ApiException(MessageHelper.LOGIN_FAILED);
            }

            await EmailVerificationCheck(user);

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (!result.Succeeded)
            {
                throw new ApiException(result.ToString());
            }

            string jwtToken = await GenerateJWTToken(user);

            RefreshToken? refreshToken = await GenerateRefreshToken();

            await RemoveExpiredRefreshTokens(user);

            user.RefreshTokens.Add(refreshToken);

            await _userManager.UpdateAsync(user);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            var authResponse = new LoginResponseDto()
            {
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                JWTToken = jwtToken,
                RefreshToken = refreshToken?.Token!,
                TenantId = await _tenantService.GetTenantId(),
                ProfilePicture = user.ProfilePicture is not null ? _identiconProvider.Create(user?.ProfilePicture?.Data).ToBase64() : string.Empty,
            };

            authResponse.JWTToken = jwtToken;

            authResponse.RefreshToken = refreshToken?.Token!;

            return authResponse;
        }

        public async Task<RegisterResponse> RegisterAsync(SignupRequestDto model)
        {
            var res = _identiconProvider.Create($"{model.FirstName} {model.LastName}");

            var newUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                CreatedOn = DateTime.UtcNow,
                ProfilePicture = new Image
                {
                    Data = res.GetBytes(),
                    Title = $"{model.FirstName}_{model.LastName}_profile"
                }
            };

            var result = await _userManager.CreateAsync(newUser, model.ConfirmPassword);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }

            User? user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                throw new ApiException(MessageHelper.SOMETHING_WENT_WRONG);
            }
            return new RegisterResponse(user.FirstName, user.LastName, user.Email);
        }

        public async Task<bool> SendForgotPasswordResetTokenAsync(ForgotPasswordRequestDto model)
        {
            User? user = await _unitOfWork.UserRepository.GetTenantUserInfoByEmail(await _tenantService.GetTenantId(), model.Email, CancellationToken.None);

            if (user is null)
            {
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            await EmailVerificationCheck(user);

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            if (!string.IsNullOrEmpty(resetToken))
            {
                return true;
            }
            return false;
        }

        public async Task<RefreshAccessTokenResponseDto> GetJWTByRefreshTokenAsync(string refreshToken)
        {
            User? account = await _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token == refreshToken));

            if (account is null)
            {
                throw new ApiException(MessageHelper.INVALID_REFRESH_TOKEN);
            }

            RefreshToken? token = account.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken);

            if (token!.IsRevoked)
            {
                await RevokeDescendantRefreshTokens(token, account, "", MessageHelper.REUSE_OF_REVOKED_ANCESTOR_TOKEN);

                var updateResult = await _userManager.UpdateAsync(account);

                throw new ApiException(MessageHelper.SOMETHING_WENT_WRONG);
            }

            RefreshToken newRefreshToken = await RotateRefreshToken(token, "");

            account.RefreshTokens.Add(newRefreshToken);

            await RemoveExpiredRefreshTokens(account);

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }

            string jwtToken = await GenerateJWTToken(account);

            var response = new RefreshAccessTokenResponseDto()
            {
                JWTToken = jwtToken,
                RefreshToken = newRefreshToken.Token!
            };

            return response;
        }
        public async Task<bool> ResetPasswordAsync(ResetPasswordRequestDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);


            if (user is null)
            {
                throw new ApiException(MessageHelper.USER_NOT_FOUND);
            }

            await EmailVerificationCheck(user);

            var result = await _userManager.ResetPasswordAsync(user, model.ResetToken, model.ConfirmNewPassword);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<bool> RevokeRefreshTokenAsync(string refreshToken)
        {
            User? account = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token == refreshToken));

            RefreshToken? token = account?.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken);

            if (account is null)
            {
                throw new ApiException(MessageHelper.INVALID_REFRESH_TOKEN);
            }

            if (!token.IsActive)
            {
                throw new ApiException(MessageHelper.REFRESH_TOKEN_EXPIRED);
            }

            UpdateRefreshTokenSettings(token, string.Empty, MessageHelper.REFRESH_TOKEN_REVOKED, string.Empty);

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }

            return result.Succeeded;
        }

        public async Task<bool> ConfirmEmailAsync(ConfirmEmailRequestDto model)
        {
            User? user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            if (await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            var result = await _userManager.ConfirmEmailAsync(user, model.EmailConfirmationToken);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<bool> IsUserNameAvailable(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var result = await _unitOfWork.UserRepository.IsUserNameAvailable(username, CancellationToken.None);

                return result;
            }
            return false;
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
                CreatedByIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
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
        #endregion
    }
}
