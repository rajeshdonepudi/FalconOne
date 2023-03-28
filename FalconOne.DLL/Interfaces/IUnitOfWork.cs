using FalconOne.DAL.Entities;

namespace FalconOne.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<RequestInformation> RequestInformationRepository { get; }
        public IGenericRepository<RefreshToken> RefreshTokenRepository { get; }
        public IGenericRepository<ApplicationClaim> UserClaimRepository { get; }
        public IGenericRepository<ApplicationPolicy> ApplicationPolicyRepository { get; }
        public IGenericRepository<ApplicationSetting> ApplicationSettingRepository { get; }
        public IGenericRepository<Department> DepartmentRepository { get; }
        public IGenericRepository<Tenant> TenantRepository { get; }
        public IGenericRepository<Post> PostRepository { get; }
        public IGenericRepository<User> UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
