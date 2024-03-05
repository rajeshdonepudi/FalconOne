using FalconOne.Models.DTOs.Security;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISecurityService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityRolesForLookup();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<string> HashPasswordForUserAsync(HashPasswordForUserDto model);
    }
}
