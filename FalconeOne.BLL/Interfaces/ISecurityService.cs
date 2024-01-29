using FalconOne.Models.DTOs.Security;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISecurityService
    {
        Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityClaimsForLookup();
        Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityRolesForLookup();
        Task<string> HashPasswordForUserAsync(HashPasswordForUserDto model);
    }
}
