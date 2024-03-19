using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Account;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FalconeOne.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        #region Fields
        private readonly RoleManager<SecurityRole> _roleManager;
        private readonly ITenantProvider _tenantService;
        #endregion

        #region Constructor
        public UserService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            RoleManager<SecurityRole> roleManager,
            ITenantProvider tenantService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _roleManager = roleManager;
            _tenantService = tenantService;
        }
        #endregion

        public async Task<bool> RevokeAccess(string refreshToken)
        {
            User? account = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token == refreshToken));

            var token = await _unitOfWork.RefreshTokenRepository.FindAsync(x => x.Token == refreshToken, CancellationToken.None);

            if (account is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REFRESH_TOKEN);
            }

            if (!token.IsActive)
            {
                throw new ApiException(ErrorMessages.REFRESH_TOKEN_EXPIRED);
            }

            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = GetClientIPAddress();
            token.ReasonRevoked = ErrorMessages.REFRESH_TOKEN_REVOKED;
            token.ReplacedByToken = string.Empty;

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }

            return result.Succeeded;
        }
        public async Task<bool> DeleteAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            User? user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<PagedList<UserInfoDto>> GetAllAsync(PageParams model)
        {
            if (model is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var users = await _unitOfWork.UserRepository
                                         .GetAllUsersByTenantIdPaginatedAsync(await _tenantService.GetTenantId(), model, CancellationToken.None);


            return users;
        }

        public async Task<UserInfoDto> GetByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            User? user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            var result = new UserInfoDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.LastName,
                ResourceAlias = user.ResourceAlias,
            };

            return result;
        }

        public async Task<bool> UpdateUserAsync(int id, SignupRequestDto model)
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> AddUserToRoleAsync(AddToRoleDto model)
        {
            if (model is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (user is null || user is null)
            {
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<bool> UpsertUser(UpsertUserDto model)
        {
            if (!string.IsNullOrEmpty(model.ResourceAlias))
            {
                var user = await _unitOfWork.UserRepository.GetUserByResourceAlias(model.ResourceAlias, CancellationToken.None);

                if (user is not null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.IsActive = model.IsActive;
                    user.EmailConfirmed = model.EmailConfirmed;
                    user.PhoneNumberConfirmed = model.PhoneConfirmed;
                    user.LockoutEnabled = model.LockoutEnabled;
                    user.TwoFactorEnabled = model.TwoFactorEnabled;
                    user.PhoneNumber = model.Phone;

                    if(!string.IsNullOrEmpty(model.ConfirmPassword))
                    {
                        var userHasPassword = await _userManager.HasPasswordAsync(user);

                        if(userHasPassword)
                        {
                            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, user.PasswordHash, model.ConfirmPassword);

                            if (!passwordChangeResult.Succeeded)
                            {
                                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
                            }
                        }
                    }

                    var updateResult = await _userManager.UpdateAsync(user);

                    return updateResult.Succeeded;
                }
            }
            else
            {
                var newUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    CreatedOn = DateTime.UtcNow,
                    IsActive = model.IsActive,
                    EmailConfirmed = model.EmailConfirmed,
                    PhoneNumberConfirmed = model.PhoneConfirmed,
                    LockoutEnabled = model.LockoutEnabled,
                    TwoFactorEnabled = model.TwoFactorEnabled,
                    PhoneNumber = model.Phone,
                    UserName = Guid.NewGuid().ToString(),
                    PasswordHash = model.ConfirmPassword,
                    Tenants = new List<TenantUser>
                    {
                        new TenantUser
                        {
                            TenantId = await _tenantService.GetTenantId()
                        }
                    }
                };

                var userCreation = await _userManager.CreateAsync(newUser, model.ConfirmPassword);

                if (!userCreation.Succeeded)
                {
                    throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
                }
                return userCreation.Succeeded;
            }
            return false;
        }

        public async Task<UserManagementDashboardInfoDto> GetDashboardInfo()
        {
            var result = await _unitOfWork.UserRepository.GetUserManagementDashboardInfoByTenantId(await _tenantService.GetTenantId(), CancellationToken.None);

            return result;
        }
    }
}
