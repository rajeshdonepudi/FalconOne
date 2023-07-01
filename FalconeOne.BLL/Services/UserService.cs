using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
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
        private readonly RoleManager<UserRole> _roleManager;
        private readonly ITenantService _tenantService;        
        #endregion

        #region Constructor
        public UserService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            RoleManager<UserRole> roleManager,
            ITenantService tenantService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _roleManager = roleManager;
            _tenantService = tenantService;
        }
        #endregion

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

        public async Task<ApiResponse> GetAllAsync(PageParams model)
        {
            List<UserDto> result = new();

            PagedList<User> users = await _unitOfWork.UserRepository.GetAllUsersByTenantIdPaginatedAsync(await _tenantService.GetTenantId(), model);

            if (!users.Any())
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.NO_USERS_FOUND));
            }

            foreach (User user in users)
            {
                UserDto res = new(user);
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

            UserDto result = new();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
        public Task<AuthenticateResponseDto> UpdateUserAsync(int id, SignupRequestDto model)
        {
            throw new NotImplementedException();
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

        public async Task<ApiResponse> AddUserToRoleAsync(AddToRoleDto addToRoleDTO)
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
    }
}
