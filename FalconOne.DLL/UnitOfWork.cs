using FalconOne.DAL.Contracts;
using FalconOne.DAL.Repositories;
using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FalconOneContext _falconOneContext;

        public UnitOfWork(FalconOneContext falconOneContext)
        {
            _falconOneContext = falconOneContext;

            RefreshTokenRepository = new GenericRepository<RefreshToken>(_falconOneContext);
            RequestInformationRepository = new RequestInformationRepository(_falconOneContext);
            UserClaimsRepository = new SecurityClaimsRepository(_falconOneContext);
            ApplicationPolicyRepository = new SecurityPolicyRepository(_falconOneContext);
            ApplicationSettingRepository = new ApplicationSettingRepository(_falconOneContext);
            DepartmentRepository = new DepartmentRepository(_falconOneContext);
            TenantRepository = new GenericRepository<Tenant>(_falconOneContext);
            PostRepository = new GenericRepository<Post>(_falconOneContext);
            UserRepository = new UserRepository(_falconOneContext);
        }

        public IRequestInformationRepository RequestInformationRepository { get; private set; }
        public IGenericRepository<RefreshToken> RefreshTokenRepository { get; private set; }
        public ISecurityClaimsRepository UserClaimsRepository { get; private set; }
        public IApplicationSettingRepository ApplicationSettingRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public ISecurityPolicyRepository ApplicationPolicyRepository { get; private set; }
        public IGenericRepository<Tenant> TenantRepository { get; private set; }
        public IGenericRepository<Post> PostRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            int added = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added).Count();
            int updated = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified).Count();
            int deleted = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Detached).Count();

            Console.WriteLine("Added: {0} Updated: {1} Deleted: {2}", added, updated, deleted);
            int res = await _falconOneContext.SaveChangesAsync();
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
