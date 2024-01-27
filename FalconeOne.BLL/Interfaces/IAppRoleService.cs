using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppRoleService
    {
        Task<SecurityRole> GetRoleAsync(string roleId);
        Task<bool> CreateRoleAsync(UserRoleDto userRole);
        Task<bool> DeleteRoleAsync(string roleId);
        Task<IEnumerable<SecurityRole>> GetAllRolesAsync();
    }
}
