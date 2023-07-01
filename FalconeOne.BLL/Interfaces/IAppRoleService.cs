using FalconeOne.BLL.Helpers;
using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppRoleService
    {
        Task<ApiResponse> GetRoleAsync(string roleId);
        Task<ApiResponse> CreateRoleAsync(UserRoleDto userRole);
        Task<ApiResponse> DeleteRoleAsync(string roleId);
        Task<ApiResponse> GetAllRolesAsync();
    }
}
