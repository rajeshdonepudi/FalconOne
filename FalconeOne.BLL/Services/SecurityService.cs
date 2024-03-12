using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FalconeOne.BLL.Services
{
    public class SecurityService : BaseService, ISecurityService
    {
        private readonly RoleManager<SecurityRole> _roleManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public SecurityService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            ITenantProvider tenantService,
            RoleManager<SecurityRole> roleManager,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, IPasswordHasher<User> passwordHasher) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }


        public async Task<string> HashPasswordForUserAsync(HashPasswordForUserDto model)
        {
            if (model is null || model.UserId is null || model.UserId is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            var hashedPassword = await Task.FromResult(_passwordHasher.HashPassword(user, model.Password));

            return hashedPassword;
        }

        public async Task<bool> CreateRoleAsync(UserRoleDto model)
        {
            if (model is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
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

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var result = await _roleManager.DeleteAsync(role);

            return result.Succeeded;
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
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            return role;
        }
    }
}
