using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL.Repositories
{
    public class SecurityClaimsRepository : GenericRepository<SecurityClaim>, ISecurityClaimsRepository
    {
        public SecurityClaimsRepository(FalconOneContext falconOneContext) : base(falconOneContext) { }

        public async Task<IEnumerable<SecurityClaim>> GetSecurityClaimsByPolicyId(Guid policyId)
        {
            return await _context.SecurityClaims.Where(x => x.ApplicationPolicyId == policyId).ToListAsync();
        }
    }
}

