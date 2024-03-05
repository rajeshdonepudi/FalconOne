using FalconOne.Models.DTOs.Users;
using FalconOne.Models.Entities;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppRoleService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<SecurityRole> GetRoleAsync(string roleId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        Task<bool> CreateRoleAsync(UserRoleDto userRole);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<bool> DeleteRoleAsync(string roleId);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SecurityRole>> GetAllRolesAsync();
    }
}
