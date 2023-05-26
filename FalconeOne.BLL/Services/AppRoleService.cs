using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Interfaces;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class AppRoleService : BaseService, IAppRoleService
    {
        private readonly RoleManager<UserRole> _roleManager;

        public AppRoleService(UserManager<User> userManager,
            IUnitOfWork unitOfWork, RoleManager<UserRole> roleManager, IHttpContextAccessor httpContextAccessor) : base(userManager, unitOfWork, httpContextAccessor)
        {
            _roleManager = roleManager;
        }
        public async Task<ApiResponse> CreateRoleAsync(UserRoleDTO userRole)
        {
            if (userRole is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.BadRequest, MessageHelper.INVALID_REQUEST));
            }

            var role = new UserRole
            {
                Name = userRole.Name,
                CreatedOn = DateTime.UtcNow
            };

            if (role is null)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.SOMETHING_WENT_WRONG));
            }

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return await Task.FromResult(new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.SOMETHING_WENT_WRONG, null, result.Errors));
            }

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public Task<ApiResponse> DeleteRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> GetAllRolesAsync()
        {
            var roles = _roleManager.Roles.ToList();
            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, roles));
        }

        public Task<ApiResponse> GetRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
