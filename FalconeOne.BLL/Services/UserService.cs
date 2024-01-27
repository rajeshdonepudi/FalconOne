using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.DTOs.Users;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        #region Fields
        private readonly RoleManager<SecurityRole> _roleManager;
        private readonly ITenantService _tenantService;
        #endregion

        #region Constructor
        public UserService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            RoleManager<SecurityRole> roleManager,
            ITenantService tenantService,
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
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            User? user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new ApiException(MessageHelper.SOMETHING_WENT_WRONG);
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<PagedListDTO> GetAllAsync(PageParams model)
        {
            if (model is null)
            {
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            var result = new List<UserDto>();

            var users = await _unitOfWork.UserRepository.GetAllUsersByTenantIdPaginatedAsync(await _tenantService.GetTenantId(), model, CancellationToken.None);

            foreach (User user in users)
            {
                var res = new UserDto(user);

                result.Add(res);
            }

            var pagedList = new PagedListDTO()
            {
                TotalCount = users.TotalCount,
                PageIndex = users.PageIndex,
                PageSize = users.PageSize,
                Records = result
            };

            return pagedList;
        }

        public async Task<UserDto> GetByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            User? user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new ApiException(MessageHelper.SOMETHING_WENT_WRONG);
            }

            var result = new UserDto();

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
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (user is null || user is null)
            {
                throw new ApiException(MessageHelper.SOMETHING_WENT_WRONG);
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
                throw new ApiException(MessageHelper.SOMETHING_WENT_WRONG);
            }
            return userCreation.Succeeded;
        }

        public async Task<ApiResponse> GetDashboardInfo()
        {
            var result = await _unitOfWork.UserRepository.GetUserManagementDashboardInfoByTenantId(await _tenantService.GetTenantId(), CancellationToken.None);

            try
            {
                return new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result);
            }
            catch (Exception)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.SOMETHING_WENT_WRONG);
            }
        }
    }
}
