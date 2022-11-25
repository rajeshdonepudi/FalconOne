﻿using FalconOne.DLL.Entities;
using FalconOne.DLL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace FalconOne.DLL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FalconOneContext _falconOneContext;
        private IDbContextTransaction dbContextTransaction;

        public UnitOfWork(FalconOneContext falconOneContext)
        {
            _falconOneContext = falconOneContext;
            RequestInformationRepository = new GenericRepository<RequestInformation>(falconOneContext);
            RefreshTokenRepository = new GenericRepository<RefreshToken>(falconOneContext);
            UserClaimRepository = new GenericRepository<UserClaim>(falconOneContext);
        }

        public IGenericRepository<RequestInformation> RequestInformationRepository { get; private set; }
        public IGenericRepository<RefreshToken> RefreshTokenRepository { get; private set; }
        public IGenericRepository<UserClaim> UserClaimRepository { get; private set; }

        public void Save()
        {
            int res = _falconOneContext.SaveChanges();
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

        public async Task CreateTransaction()
        {
            dbContextTransaction = await _falconOneContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await dbContextTransaction.CommitAsync();
        }
    }
}
