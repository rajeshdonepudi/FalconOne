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

            PagedList<User> users = await _unitOfWork.UserRepository.GetAllUsersByTenantIdPaginatedAsync(await _tenantService.GetTenantId(), model, CancellationToken.None);

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

            SecurityRole? role = await _roleManager.FindByIdAsync(addToRoleDTO.RoleId);

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

        public async Task<ApiResponse> AddUser(AddUserDto model)
        {
            User newUser = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CreatedOn = DateTime.UtcNow,
                EmailConfirmed = model.IsEmailConfirmed,
                PhoneNumberConfirmed = model.IsPhoneConfirmed,
                PhoneNumber = model.Phone,
                LockoutEnabled = model.IsLockoutEnabled,
                UserName = model.UserName,
                TenantUsers = new List<TenantUser> { new TenantUser { TenantId = await _tenantService.GetTenantId() } }
            };

            try
            {



                IdentityResult userCreation = await _userManager.CreateAsync(newUser, model.ConfirmPassword);

                if (userCreation.Succeeded)
                {
                    if(model.Roles is not null && model.Roles.Any())
                    {
                        foreach (Guid roleId in model.Roles)
                        {
                            SecurityRole? role = await _roleManager.FindByIdAsync(roleId.ToString());

                            if(role is not null)
                            {
                                IdentityResult roleAddition = await _userManager.AddToRoleAsync(newUser, role?.Name!);
                            }
                        }
                    }

                    if(model.Permissions is not null && model.Permissions.Any())
                    {
                        foreach (Guid permissionId in model.Permissions)
                        {
                            var claim = await _unitOfWork.SecurityClaimsRepository.GetSecurityClaimByIdAsync(permissionId, await _tenantService.GetTenantId(), CancellationToken.None);

                            if(claim is not null)
                            {
                                var claimAddition = await _userManager.AddClaimAsync(newUser, new System.Security.Claims.Claim(claim.Type, claim.Value));
                            }
                        }
                    }
                }
                return new ApiResponse(HttpStatusCode.Created, MessageHelper.USER_CREATED_SUCCESSFULLY);
            }
            catch (Exception)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError, MessageHelper.USER_CREATION_FAILED);
            }
        }
    }
}
