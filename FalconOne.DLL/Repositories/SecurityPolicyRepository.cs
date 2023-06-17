using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL.Repositories
{
    public class SecurityPolicyRepository : GenericRepository<SecurityPolicy>, ISecurityPolicyRepository
    {
        public SecurityPolicyRepository(FalconOneContext falconOneContext) : base(falconOneContext) { }

        public async Task<IEnumerable<SecurityPolicy>> GetAllSecurityPoliciesWithClaimsAsync()
        {
            return await _context.SecurityPolicies.Include(x => x.PolicyClaims).ToListAsync();
        }
    }
}

