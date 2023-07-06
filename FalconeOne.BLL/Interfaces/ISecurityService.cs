using FalconeOne.BLL.Helpers;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISecurityService
    {
        Task<ApiResponse> GetTenantSecurityClaimsForLookup();
        Task<ApiResponse> GetTenantSecurityRolesForLookup();
    }
}
