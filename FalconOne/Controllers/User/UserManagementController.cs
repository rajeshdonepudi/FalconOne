using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Account;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;
using FalconOne.ResourceCodes;
using FalconOne.Security;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : BaseSecureController
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService accountService)
        {
            _userService = accountService;
        }

        [HttpGet("dashboard-info")]
        [ApiAuthorize(Policy = SecurityPolicies.TENANT_ADMIN_POLICY)]
        [ResourceIdentifier(ResourceIdentifier.User.USER_MANAGMENT_DASHBOARD)]
        public async Task<IActionResult> Dashboard()
        {
            var result = await _userService.GetDashboardInfo();

            return Ok(result);
        }

        [HttpPost("add-user-to-role")]
        [ApiAuthorize(Policy = SecurityPolicies.TENANT_ADMIN_POLICY)]
        public async Task<IActionResult> AddUserToRole(AddToRoleDto model)
        {
            var result = await _userService.AddUserToRoleAsync(model);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add-user")]
        [ApiAuthorize(Policy = SecurityPolicies.TENANT_ADMIN_POLICY)]
        [ResourceIdentifier(ResourceIdentifier.User.ADD_NEW_USER)]
        public async Task<IActionResult> AddUser(UpsertUserDto model)
        {
            var result = await _userService.UpsertUser(model);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete-user/{resourceAlias}")]
        [ApiAuthorize(Policy = SecurityPolicies.TENANT_ADMIN_POLICY)]
        [ResourceIdentifier(ResourceIdentifier.User.DELETE_USER)]
        public async Task<IActionResult> DeleteUser(string resourceAlias)
        {
            var result = await _userService.DeleteUserAsync(resourceAlias, CancellationToken.None);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("all-users")]
        [ApiAuthorize(Policy = SecurityPolicies.TENANT_ADMIN_POLICY)]
        [ResourceIdentifier(ResourceIdentifier.Account.GET_USER)]
        public async Task<IActionResult> GetAllUsers(PageParams model)
        {
            var response = await _userService.GetAllActiveAsync(model);

            return Ok(response);
        }

        [HttpGet("get-user")]
        [ApiAuthorize(Policy = SecurityPolicies.TENANT_ADMIN_POLICY)]
        [ResourceIdentifier(ResourceIdentifier.Account.GET_USER)]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _userService.GetByIdAsync(userId);

            return Ok(response);
        }

        [HttpPost("revoke-refresh-token")]
        [ApiAuthorize(Policy = SecurityPolicies.TENANT_ADMIN_POLICY)]
        [ResourceIdentifier(ResourceIdentifier.Account.REVOKE_REFRESH_TOKEN)]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshTokenRequestDto model)
        {
            var response = await _userService.RevokeAccess(model.RefreshToken);

            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("user-created-year")]
        [ApiAuthorize(Policy = SecurityPolicies.TENANT_ADMIN_POLICY)]
        [ResourceIdentifier(ResourceIdentifier.Account.REVOKE_REFRESH_TOKEN)]
        public async Task<IActionResult> UserCreatedByYear()
        {
            return Ok(await _userService.UserCreatedByYears());
        }
    }
}
