using FalconOne.DAL.Contracts;
using FalconOne.DAL.Repositories;
using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FalconOneContext _falconOneContext;
        private readonly IMemoryCache _memoryCache;

        public UnitOfWork(FalconOneContext falconOneContext, IMemoryCache memoryCache)
        {
            _falconOneContext = falconOneContext;
            _memoryCache = memoryCache;

            RefreshTokenRepository = new GenericRepository<RefreshToken>(_falconOneContext, _memoryCache);
            RequestInformationRepository = new SystemLogsRepository(_falconOneContext, _memoryCache);
            SecurityClaimsRepository = new SecurityClaimsRepository(_falconOneContext, _memoryCache);
            ApplicationPolicyRepository = new SecurityPolicyRepository(_falconOneContext, _memoryCache);
            ApplicationSettingRepository = new SiteSettingRepository(_falconOneContext, _memoryCache);
            DepartmentRepository = new DepartmentRepository(_falconOneContext, _memoryCache);
            TenantRepository = new GenericRepository<Tenant>(_falconOneContext, _memoryCache);
            PostRepository = new GenericRepository<Post>(_falconOneContext, _memoryCache);
            UserRepository = new UserRepository(_falconOneContext, _memoryCache);
            SecurityRolesRepository = new SecurityRolesRepository(_falconOneContext, memoryCache);
        }

        public ISystemLogRepository RequestInformationRepository { get; private set; }
        public IGenericRepository<RefreshToken> RefreshTokenRepository { get; private set; }
        public ISecurityClaimsRepository SecurityClaimsRepository { get; private set; }
        public ISecurityRolesRepository SecurityRolesRepository { get; private set; }
        public ISiteSettingRepository ApplicationSettingRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public ISecurityPolicyRepository ApplicationPolicyRepository { get; private set; }
        public IGenericRepository<Tenant> TenantRepository { get; private set; }
        public IGenericRepository<Post> PostRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            int added = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added).Count();
            int updated = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified).Count();
            int deleted = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Detached).Count();

            Console.WriteLine("Added: {0} Updated: {1} Deleted: {2}", added, updated, deleted);
            int res = await _falconOneContext.SaveChangesAsync(cancellationToken);
            Console.WriteLine("No of records updated: {0}", res);
            Console.ResetColor();
            return res;
        }

        async void IDisposable.Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual async Task Dispose(bool disposing)
        {
            if (disposing)
            {
                await _falconOneContext.DisposeAsync();
            }
        }
    }
}
