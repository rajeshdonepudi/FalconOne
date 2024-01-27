using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ISystemLogRepository RequestInformationRepository { get; }
        IGenericRepository<RefreshToken> RefreshTokenRepository { get; }
        ISecurityClaimsRepository SecurityClaimsRepository { get; }
        ISecurityRolesRepository SecurityRolesRepository { get; }
        ISecurityPolicyRepository ApplicationPolicyRepository { get; }
        IGenericRepository<Tenant> TenantRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
