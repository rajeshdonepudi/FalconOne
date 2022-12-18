using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;

namespace FalconOne.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FalconOneContext _falconOneContext;

        public UnitOfWork(FalconOneContext falconOneContext,
            IGenericRepository<RequestInformation> requestInformationRepository,
            IGenericRepository<RefreshToken> refreshTokenRepository,
            IGenericRepository<ApplicationClaim> userClaimRepository,
            IGenericRepository<ApplicationPolicy> appPolicyRepository,
            IGenericRepository<ApplicationSetting> applicationSettingRepository,
            IGenericRepository<Department> departmentRepository)
        {
            _falconOneContext = falconOneContext;
            RefreshTokenRepository = refreshTokenRepository;
            RequestInformationRepository = requestInformationRepository;
            UserClaimRepository = userClaimRepository;
            ApplicationPolicyRepository = appPolicyRepository;
            ApplicationSettingRepository = applicationSettingRepository;
            DepartmentRepository = departmentRepository;
        }

        public IGenericRepository<RequestInformation> RequestInformationRepository { get; private set; }
        public IGenericRepository<RefreshToken> RefreshTokenRepository { get; private set; }
        public IGenericRepository<ApplicationClaim> UserClaimRepository { get; private set; }
        public IGenericRepository<ApplicationPolicy> ApplicationPolicyRepository { get; private set; }
        public IGenericRepository<ApplicationSetting> ApplicationSettingRepository { get; private set; }
        public IGenericRepository<Department> DepartmentRepository { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var added = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added).Count();
            var updated = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified).Count();
            var deleted = _falconOneContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Detached).Count();

            Console.WriteLine("Added: {0} Updated: {1} Deleted: {2}", added, updated, deleted);
            var res = await _falconOneContext.SaveChangesAsync();
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
