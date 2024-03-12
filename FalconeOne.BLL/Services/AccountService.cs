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
            ITenantProvider tenantService,
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
            User user = await _unitOfWork.UserRepository
                                          .GetTenantUserInfoByEmail(await _tenantService.GetTenantId(), model.Email, CancellationToken.None);

            if (user is null)
            {
                throw new ApiException(ErrorMessages.LOGIN_FAILED);
            }

            await EmailVerificationCheck(user);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, true);

            HandleSignInAction(signInResult);

            var accessToken = await GenerateAccessTokenAsync(user);
            var refreshToken = await GenerateRefreshTokenAsync();

            await RemoveExpiredRefreshTokensAsync(user.Id, CancellationToken.None);

            user.RefreshTokens.Add(refreshToken);

            await _userManager.UpdateAsync(user);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            var response = new LoginResponseDto()
            {
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                AccessToken = accessToken,
                RefreshToken = refreshToken?.Token!,
                TenantId = await _tenantService.GetTenantId(),
                ProfilePicture = user.ProfilePicture is not null ? GenerateProfilePicture(user?.ProfilePicture?.Data) : string.Empty,
            };

            response.AccessToken = accessToken;

            response.RefreshToken = refreshToken?.Token!;

            return response;
        }

        public async Task<RegisterResponse> RegisterAsync(SignupRequestDto model)
        {
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
                    Data = GenerateProfilePicture(model.FirstName, model.LastName),
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
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }
            return new RegisterResponse(user.FirstName, user.LastName, user.Email);
        }

        public async Task<bool> SendForgotPasswordResetTokenAsync(ForgotPasswordRequestDto model)
        {
            User? user = await _unitOfWork.UserRepository.GetTenantUserInfoByEmail(await _tenantService.GetTenantId(), model.Email, CancellationToken.None);

            if (user is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
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
            User account = await _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token == refreshToken));

            if (account is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REFRESH_TOKEN);
            }

            RefreshToken? token = account.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken);

            if (token!.IsRevoked)
            {
                await RevokeDescendantRefreshTokensAsync(token, account, "", ErrorMessages.REUSE_OF_REVOKED_ANCESTOR_TOKEN);

                var updateResult = await _userManager.UpdateAsync(account);

                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            RefreshToken newRefreshToken = await RotateRefreshTokenAsync(token, GetClientIPAddress());

            account.RefreshTokens.Add(newRefreshToken);

            await RemoveExpiredRefreshTokensAsync(account.Id, CancellationToken.None);

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }

            string jwtToken = await GenerateAccessTokenAsync(account);

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
                throw new ApiException(ErrorMessages.USER_NOT_FOUND);
            }

            await EmailVerificationCheck(user);

            var result = await _userManager.ResetPasswordAsync(user, model.ResetToken, model.ConfirmNewPassword);

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
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            if (await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var result = await _userManager.ConfirmEmailAsync(user, model.EmailConfirmationToken);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<bool> IsUserNameAvailableAsync(string username)
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
        private async Task<string> GenerateAccessTokenAsync(User user)
        {
            IList<Claim> claims = await _userManager.GetClaimsAsync(user);

            var roleClaims = await _unitOfWork.UserRepository.GetUserRoles(await _tenantService.GetTenantId(), user.Id, CancellationToken.None);

            foreach (var claim in roleClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, claim.Name!));
            }

            claims.Add(new Claim("TenantId", (await _tenantService.GetTenantId()).ToString()));

            claims.Add(new Claim("UserId", user.Id.ToString()));

            string token = await _tokenService.GenerateJWTToken(user, claims);

            return await Task.FromResult(token);
        }

        private byte[] GenerateProfilePicture(string input1, string input2)
        {
            return _identiconProvider.Create($"{input1} {input2}").GetBytes();
        }

        private string GenerateProfilePicture(byte[] data)
        {
            return _identiconProvider.Create(data).ToBase64();
        }

        private async Task<RefreshToken> GenerateRefreshTokenAsync()
        {
            RefreshToken refreshToken = await GetRefreshTokenAsync();

            List<RefreshToken> refreshTokens = await _userManager.Users.AsNoTracking().SelectMany(x => x.RefreshTokens).ToListAsync();

            if (refreshTokens.Any())
            {
                bool isUniqueToken = !refreshTokens.Any(t => t.Token == refreshToken.Token);

                if (!isUniqueToken)
                {
                    RefreshToken newToken = await GenerateRefreshTokenAsync();
                    return await Task.FromResult(newToken);
                }
            }
            return await Task.FromResult(refreshToken);
        }
        private async Task<RefreshToken> GetRefreshTokenAsync()
        {
            return await Task.FromResult(new RefreshToken
            {
                Token = Convert.ToHexString(GetRandomBytes(64)),
                Expires = DateTime.UtcNow.AddDays(double.Parse(await _appConfigService.GetValueAsync("JWT:RefreshTokenValidityInDays"))),
                Created = DateTime.UtcNow,
                CreatedByIp = GetClientIPAddress(),
            });
        }
        private byte[] GetRandomBytes(int length)
        {
            return RandomNumberGenerator.GetBytes(length);
        }

        private async Task RemoveExpiredRefreshTokensAsync(Guid userId, CancellationToken cancellationToken)
        {
            var tokens = await _unitOfWork.RefreshTokenRepository.GetAllAsync(x => x.UserId == userId, cancellationToken);

            var lastRefreshToken = tokens.LastOrDefault();

            var oldTokens = tokens.Where(x => x.Id != lastRefreshToken!.Id).ToList();

            _unitOfWork.RefreshTokenRepository.RemoveRangeAsync(oldTokens);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task RevokeDescendantRefreshTokensAsync(RefreshToken refreshToken, User user, string ipAddress, string reason)
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
                        await RevokeDescendantRefreshTokensAsync(childRefreshToken, user, ipAddress, reason);
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

        private async Task<RefreshToken> RotateRefreshTokenAsync(RefreshToken refreshToken, string ipAddress)
        {
            RefreshToken newRefreshToken = await GenerateRefreshTokenAsync();
            UpdateRefreshTokenSettings(refreshToken, ipAddress, ErrorMessages.REPLACED_WITH_NEW_TOKEN, newRefreshToken.Token!);
            return newRefreshToken;
        }

        private void HandleSignInAction(SignInResult result)
        {
            if (result.IsLockedOut)
            {
                throw new ApiException(MessageHelper.LoginErrors.ACCOUNT_LOCKED);
            }

            if (result.IsNotAllowed)
            {
                throw new ApiException(MessageHelper.LoginErrors.LOGIN_FAILED);
            }
        }
        #endregion
    }
}
