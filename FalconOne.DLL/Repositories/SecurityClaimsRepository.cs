using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL.Repositories
{
    public class SecurityClaimsRepository : GenericRepository<SecurityClaim>, ISecurityClaimsRepository
    {
        public SecurityClaimsRepository(FalconOneContext falconOneContext, IMemoryCache memoryCache) : base(falconOneContext, memoryCache) { }

        public async Task<SecurityClaim> GetSecurityClaimByIdAsync(Guid claimId, Guid tenantId, CancellationToken cancellationToken)
        {
            return await _context.SecurityClaims.FirstOrDefaultAsync(x => x.Id == claimId && x.TenantId == tenantId);
        }

        public async Task<IEnumerable<SecurityClaim>> GetSecurityClaimsByPolicyId(Guid policyId, CancellationToken cancellationToken)
        {
            return await _context.SecurityClaims.Where(x => x.ApplicationPolicyId == policyId).ToListAsync();
        }

        public async Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityClaimsForLookup(Guid tenantId, CancellationToken cancellationToken)
        {
            return await _context.SecurityClaims.Where(x => x.TenantId == tenantId).Select(x => new KeyValuePair<Guid, string>(x.Id, x.Value)).ToListAsync();
        }
    }
}

