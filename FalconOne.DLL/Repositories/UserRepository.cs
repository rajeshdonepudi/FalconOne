using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FalconOneContext falconOneContext, IMemoryCache memoryCache) : base(falconOneContext, memoryCache) { }

        public async Task<PagedList<User>> GetAllUsersByTenantIdPaginatedAsync(Guid tenantId, PageParams pageParams, CancellationToken cancellationToken)
        {
            List<User> records = await _context.Users.Where(x => x.Tenants.Any(x => x.TenantId == tenantId))
                                                     .Skip((pageParams.PageIndex - 1) * pageParams.PageSize)
                                                     .Take(pageParams.PageSize)
                                                     .ToListAsync(cancellationToken);

            return new PagedList<User>(records, await _context.Users.LongCountAsync(cancellationToken), pageParams.PageIndex, pageParams.PageSize);
        }

        public async Task<bool> IsUserNameAvailable(string username, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(x => x.UserName != username, cancellationToken);
        }
    }
}

