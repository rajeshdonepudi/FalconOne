using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;
using FalconOne.Models.Entities;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISecurityService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<string> HashPasswordForUserAsync(HashPasswordForUserDto model);

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
