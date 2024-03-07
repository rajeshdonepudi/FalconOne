using FalconOne.DAL.Contracts;
using FalconOne.Extensions.EntityFramework;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FalconOneContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

        public async Task<PagedList<User>> GetAllUsersByTenantIdPaginatedAsync(Guid tenantId, PageParams pageParams, CancellationToken cancellationToken)
        {
            var result = await _context.Users.Where(x => x.Tenants.Any(x => x.TenantId == tenantId))
                                              .OrderByDescending(x => x.CreatedOn)
                                              .AsNoTracking()
                                              .ToPagedListAsync(pageParams);

            return result;
        }

        public async Task<User> GetTenantUserInfoByEmail(Guid tenantId, string email, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(x => x.Email == email && x.Tenants.Any(x => x.TenantId == tenantId))
                                           .Include(x => x.ProfilePicture)
                                           .FirstOrDefaultAsync(cancellationToken)!;
            return user;
        }

        public async Task<User> GetUserInfoByEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(x => x.Email == email)
                                           .Include(x => x.ProfilePicture)
                                           .FirstOrDefaultAsync(cancellationToken)!;
            return user;
        }

        public async Task<UserManagementDashboardInfoDto> GetUserManagementDashboardInfoByTenantId(Guid tenantId, CancellationToken cancellationToken)
        {
            var query = _context.Users.AsQueryable()
                                      .Where(x => x.Tenants.Any(x => x.TenantId == tenantId));

            var info = new UserManagementDashboardInfoDto();

            info.TotalUsers = await query.CountAsync();
            info.DeactivatedUsers = await query.CountAsync(x => !x.IsActive);
            info.ActiveUsers = await query.CountAsync(x => x.IsActive);
            info.VerifiedUsers = await query.CountAsync(x => x.EmailConfirmed);
            info.LockedUsers = await query.CountAsync(x => x.LockoutEnd != null);
            info.UnVerifiedUsers = await query.CountAsync(x => !x.EmailConfirmed);

            return info;
        }

        public async Task<List<SecurityRole>> GetUserRoles(Guid tenantId, Guid userId, CancellationToken cancellationToken)
        {
            var result = await _context.TenantUsers.Where(x => x.TenantId == tenantId && x.UserId == userId)
                                                   .SelectMany(x => x.TenantUserRoles)
                                                   .Select(x => x.SecurityRole)
                                                   .AsNoTracking()
                                                   .ToListAsync(cancellationToken);
            return result;
        }

        public async Task<bool> IsUserNameAvailable(string username, CancellationToken cancellationToken)
        {
            var result = await _context.Users.AnyAsync(x => x.UserName != username, cancellationToken);

            return result;
        }
    }
}

