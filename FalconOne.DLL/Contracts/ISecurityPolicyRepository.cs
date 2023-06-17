using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface ISecurityPolicyRepository : IGenericRepository<SecurityPolicy>
    {
        Task<IEnumerable<SecurityPolicy>> GetAllSecurityPoliciesWithClaimsAsync();
    }
}
