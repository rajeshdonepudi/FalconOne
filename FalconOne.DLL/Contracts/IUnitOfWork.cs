using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ISystemLogRepository RequestInformationRepository { get; }
        IGenericRepository<RefreshToken> RefreshTokenRepository { get; }
        ISecurityRolesRepository SecurityRolesRepository { get; }
        IGenericRepository<Tenant> TenantRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
