using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL.Repositories
{
    public class SecurityRolesRepository : GenericRepository<SecurityRole>, ISecurityRolesRepository
    {
        public SecurityRolesRepository(FalconOneContext falconOneContext, IMemoryCache memoryCache) : base(falconOneContext, memoryCache) { }

        public async Task<IEnumerable<KeyValuePair<Guid, string>>> GetTenantSecurityRolesForLookup(Guid tenantId, CancellationToken cancellationToken)
        {
            return await _context.Roles.Where(x => x.TenantId == tenantId).Select(x => new KeyValuePair<Guid, string>(x.Id, x.Name)).ToListAsync();
        }
    }
}

