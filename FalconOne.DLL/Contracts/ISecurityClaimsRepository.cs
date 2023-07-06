using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface ISecurityClaimsRepository : IGenericRepository<SecurityClaim>
    {
        Task<IEnumerable<SecurityClaim>> GetSecurityClaimsByPolicyId(Guid policyId, CancellationToken cancellationToken);

        Task<SecurityClaim> GetSecurityClaimByIdAsync(Guid claimId, Guid tenantId, CancellationToken cancellationToken);

        Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityClaimsForLookup(Guid tenantId, CancellationToken cancellationToken);
    }
}
