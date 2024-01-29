using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Users;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FalconeOne.BLL.Services
{
    public class AppRoleService : BaseService, IAppRoleService
    {
        private readonly RoleManager<SecurityRole> _roleManager;

        public AppRoleService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            RoleManager<SecurityRole> roleManager,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, ITenantService tenantService) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(UserRoleDto model)
        {
            if (model is null)
            {
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            var role = new SecurityRole()
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public Task<bool> DeleteRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SecurityRole>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return roles;
        }

        public async Task<SecurityRole> GetRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role is null)
            {
                throw new ApiException(MessageHelper.SOMETHING_WENT_WRONG);
            }

            return role;
        }
    }
}
