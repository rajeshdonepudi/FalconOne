using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL.Repositories
{
    public class SecurityPolicyRepository : GenericRepository<SecurityPolicy>, ISecurityPolicyRepository
    {
        public SecurityPolicyRepository(FalconOneContext falconOneContext, IMemoryCache memoryCache) : base(falconOneContext, memoryCache) { }

        public async Task<IEnumerable<SecurityPolicy>> GetAllSecurityPoliciesWithClaimsAsync(CancellationToken cancellationToken)
        {
            return await _context.SecurityPolicies.Include(x => x.PolicyClaims).ToListAsync(cancellationToken);
        }
    }
}

