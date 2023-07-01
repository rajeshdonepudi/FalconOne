using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FalconOneContext falconOneContext) : base(falconOneContext) { }

        public async Task<PagedList<User>> GetAllUsersByTenantIdPaginatedAsync(Guid tenantId, PageParams pageParams)
        {
            List<User> records = await _context.Users.Where(x => x.Tenants.Any(x => x.TenantId == tenantId))
                                                     .Skip((pageParams.PageIndex - 1) * pageParams.PageSize)
                                                     .Take(pageParams.PageSize)
                                                     .ToListAsync();

            return new PagedList<User>(records, await _context.Users.LongCountAsync(), pageParams.PageIndex, pageParams.PageSize);
        }

        public async Task<bool> IsUserNameAvailable(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName != username);
        }
    }
}

