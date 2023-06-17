using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface ISecurityClaimsRepository : IGenericRepository<SecurityClaim>
    {
        Task<IEnumerable<SecurityClaim>> GetSecurityClaimsByPolicyId(Guid policyId);
    }
}
