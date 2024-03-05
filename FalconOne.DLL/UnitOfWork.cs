using FalconOne.DAL.Contracts;
using FalconOne.DAL.Repositories;
using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FalconOneContext _context;
        private readonly IMemoryCache _memoryCache;

        public UnitOfWork(FalconOneContext context, IMemoryCache cache)
        {
            _context = context;
            _memoryCache = cache;

            RefreshTokenRepository = new GenericRepository<RefreshToken>(_context, _memoryCache);
            RequestInformationRepository = new SystemLogsRepository(_context, _memoryCache);
            TenantRepository = new GenericRepository<Tenant>(_context, _memoryCache);
            UserRepository = new UserRepository(_context, _memoryCache);
            SecurityRolesRepository = new SecurityRolesRepository(_context, _memoryCache);
        }

        public ISystemLogRepository RequestInformationRepository { get; private set; }
        public IGenericRepository<RefreshToken> RefreshTokenRepository { get; private set; }
        public ISecurityRolesRepository SecurityRolesRepository { get; private set; }
        public IGenericRepository<Tenant> TenantRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public async Task<int> SaveChangesAsync(CancellationToken token)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            int added = _context.ChangeTracker.Entries()
                                              .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                                              .Count();

            int updated = _context.ChangeTracker.Entries()
                                                .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                                                .Count();

            int deleted = _context.ChangeTracker.Entries()
                                                .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                                                .Count();

            Console.WriteLine("Added: {0} Updated: {1} Deleted: {2}", added, updated, deleted);

            int res = await _context.SaveChangesAsync(token);

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
                await _context.DisposeAsync();
            }
        }
    }
}
