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

        public async Task<PagedList<User>> GetAllAsync(PageParams model)
        {
            if (model is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var result = new List<UserInfoDto>();

            var users = await _unitOfWork.UserRepository
                                         .GetAllUsersByTenantIdPaginatedAsync(await _tenantService.GetTenantId(), model, CancellationToken.None);

            foreach (var user in users.Items)
            {
                var res = new UserInfoDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.LastName,
                    Id = user.Id,
                };
                result.Add(res);
            }
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
                Id = user.Id,
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

        public async Task<bool> AddUser(AddUserDto model)
        {
            var newUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CreatedOn = DateTime.UtcNow,
                IsActive = model.IsActive,
                EmailConfirmed = model.IsEmailConfirmed,
                PhoneNumberConfirmed = model.IsPhoneConfirmed,
                LockoutEnabled = model.IsLockoutEnabled,
                TwoFactorEnabled = model.IsTwoFactorEnabled,
                PhoneNumber = model.Phone,
                UserName = model.UserName,
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

        public async Task<UserManagementDashboardInfoDto> GetDashboardInfo()
        {
            var result = await _unitOfWork.UserRepository.GetUserManagementDashboardInfoByTenantId(await _tenantService.GetTenantId(), CancellationToken.None);

            return result;
        }
    }
}
