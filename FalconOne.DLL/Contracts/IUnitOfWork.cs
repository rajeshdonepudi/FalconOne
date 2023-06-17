using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRequestInformationRepository RequestInformationRepository { get; }
        IGenericRepository<RefreshToken> RefreshTokenRepository { get; }
        ISecurityClaimsRepository UserClaimsRepository { get; }
        IApplicationSettingRepository ApplicationSettingRepository { get; }
        ISecurityPolicyRepository ApplicationPolicyRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IGenericRepository<Tenant> TenantRepository { get; }
        IGenericRepository<Post> PostRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
