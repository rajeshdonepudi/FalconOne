using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface ISecurityRolesRepository : IGenericRepository<SecurityRole>
    {
        Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityRolesForLookup(Guid tenantId, CancellationToken cancellationToken);
    }
}
