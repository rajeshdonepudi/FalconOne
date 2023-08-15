using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
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
            List<User> records = await _context.Users.Where(x => x.TenantUsers.Any(x => x.TenantId == tenantId))
                                                     .OrderByDescending(x => x.CreatedOn)
                                                     .Skip((pageParams.Page) * pageParams.PageSize)
                                                     .Take(pageParams.PageSize)
                                                     .AsNoTracking()
                                                     .ToListAsync(cancellationToken);

            var totalUsersCount = await _context.Users.Where(x => x.TenantUsers.Any(x => x.TenantId == tenantId)).LongCountAsync(cancellationToken);

            return new PagedList<User>(records, totalUsersCount, pageParams.Page, pageParams.PageSize);
        }

        public async Task<User> GetTenantUserInfoByEmail(Guid tenantId, string email, CancellationToken cancellationToken)
        {
            return await _context.Users.Where(x => x.Email == email && x.TenantUsers.Any(x => x.TenantId == tenantId))
                                       .Include(x => x.ProfilePicture)
                                       .Include(x => x.RefreshTokens)
                                       .FirstOrDefaultAsync(cancellationToken)!;
        }

        public async Task<UserManagementDashboardInfo> GetUserManagementDashboardInfoByTenantId(Guid tenantId, CancellationToken cancellationToken)
        {
            var query = _context.Users.AsQueryable().Where(x => x.TenantUsers.Any(x => x.TenantId == tenantId));

            var info = new  UserManagementDashboardInfo();

            info.TotalUsers = await query.CountAsync();
            info.DeactivatedUsers = await query.CountAsync(x => !x.IsActive);
            info.ActiveUsers = await query.CountAsync(x => x.IsActive);
            info.VerifiedUsers = await query.CountAsync(x => x.EmailConfirmed);
            info.LockedUsers = await query.CountAsync(x => x.LockoutEnd != null);
            info.UnVerifiedUsers = await query.CountAsync(x => !x.EmailConfirmed);

            return info;
        }

        public async Task<bool> IsUserNameAvailable(string username, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(x => x.UserName != username, cancellationToken);
        }
    }
}

