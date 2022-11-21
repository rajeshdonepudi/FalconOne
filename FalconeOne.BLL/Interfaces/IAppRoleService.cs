using FalconeOne.BLL.Helpers;
using Utilities.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppRoleService
    {
        Task<ApiResponse> GetRoleAsync(string roleId);
        Task<ApiResponse> CreateRoleAsync(UserRoleDTO userRole);
        Task<ApiResponse> DeleteRoleAsync(string roleId);
        Task<ApiResponse> GetAllRolesAsync();
    }
}
