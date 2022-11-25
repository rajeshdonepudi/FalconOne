using FalconOne.DLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<RequestInformation> RequestInformationRepository { get; }
        public IGenericRepository<RefreshToken> RefreshTokenRepository { get;}
        public IGenericRepository<UserClaim> UserClaimRepository { get; }

        void Save();
        Task CreateTransaction();
        Task CommitTransaction();
    }
}
