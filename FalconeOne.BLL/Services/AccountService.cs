using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Extensions.Http;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FalconeOne.BLL.Services
{
    public class AccountService : BaseService, IAccountService
    {
        #region Fields
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly ITokenService _tokenService;
        private readonly ITenantService _tenantService;
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
            RoleManager<UserRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            ITokenService tokenService,
            ITenantService tenantService,
            IAppConfigService appConfigService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _optionsAccessor = optionsAccessor;
            _tokenService = tokenService;
            _tenantService = tenantService;
            _appConfigService = appConfigService;
        }
        #endregion

        #region Implementation

        public async Task<ApiResponse> AuthenticateUserAsync(AuthenticateRequestDTO model)
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

            await _unitOfWork.SaveChangesAsync();

            AuthenticateResponseDTO authResponse = new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                JWTToken = jwtToken,
                RefreshToken = refreshToken?.Token,
                Tenants = user.Tenants.Select(x => x.TenantId).ToList()
            };

            authResponse.JWTToken = jwtToken;

            authResponse.RefreshToken = refreshToken.Token!;

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.LOGIN_SUCCESSFULL, authResponse));
        }

        public async Task<ApiResponse> CreateNewUserAsync(RegisterNewUserRequestDTO model)
        {
            User newUser = new() { };

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
            UserDTO account = new() { };

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.USER_CREATED_SUCCESSFULLY, account));
        }

        public async Task<ApiResponse> DeleteAsync(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.INVALID_USER_ID));
            }

            User? user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            IdentityResult result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.USER_DELETION_FAILED));
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.NoContent, MessageHelper.USER_DELETED_SUCCESSFULLY));
        }

        public async Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequestDTO model)
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

        public async Task<ApiResponse> GetAllAsync(PageParams model)
        {
            List<UserDTO> result = new();

            PagedList<User> users = await _unitOfWork.UserRepository.GetAllUsersByTenantIdPaginatedAsync(await _tenantService.GetTenantId(), model);

            if (!users.Any())
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.NO_USERS_FOUND));
            }

            foreach (User user in users)
            {
                UserDTO res = new(user);
                result.Add(res);
            }

            PagedListDTO pagedList = new()
            {
                TotalCount = users.TotalCount,
                PageIndex = users.PageIndex,
                PageSize = users.PageSize,
                Records = result
            };

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, pagedList));
        }

        public async Task<ApiResponse> GetByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.INVALID_USER_ID));
            }

            User? user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            UserDTO result = new();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
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

            AuthenticateResponseDTO response = new()
            {
                JWTToken = jwtToken,
                RefreshToken = newRefreshToken.Token
            };

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, response));
        }
        public async Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequestDTO model)
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

        public Task<AuthenticateResponseDTO> UpdateUserAsync(int id, RegisterNewUserRequestDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> VerifyEmailAsync(VerifyEmailDTO model)
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

        public async Task<ApiResponse> AddUserToRoleAsync(AddToRoleDTO addToRoleDTO)
        {
            if (addToRoleDTO is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.INVALID_REQUEST));
            }

            User? user = await _userManager.FindByIdAsync(addToRoleDTO.UserId);

            if (user is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.USER_NOT_FOUND));
            }

            UserRole? role = await _roleManager.FindByIdAsync(addToRoleDTO.RoleId);

            if (role is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.NotFound, MessageHelper.ROLE_NOT_FOUND));
            }

            IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);

            if (!result.Succeeded)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.SOMETHING_WENT_WRONG, null, result.Errors));
            }

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        #endregion

        #region Private methods
        private async Task<string> GenerateJWTToken(User user)
        {
            IList<Claim> claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim("Tenants", string.Join(',', user.Tenants.Select(x => x.TenantId).ToList())));

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
        #endregion
    }
}
