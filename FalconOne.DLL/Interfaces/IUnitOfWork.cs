using FalconOne.DLL.Entities;

namespace FalconOne.DLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<RequestInformation> RequestInformationRepository { get; }
        public IGenericRepository<RefreshToken> RefreshTokenRepository { get; }
        public IGenericRepository<ApplicationClaim> UserClaimRepository { get; }
        public IGenericRepository<ApplicationPolicy> ApplicationPolicyRepository { get; }
        public IGenericRepository<ApplicationSetting> ApplicationSettingRepository { get; }

        void Save();
        Task CreateTransaction();
        Task CommitTransaction();
    }
}
