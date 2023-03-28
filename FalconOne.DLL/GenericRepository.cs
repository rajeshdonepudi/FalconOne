using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Utilities.Helpers;

namespace FalconOne.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FalconOneContext _falconOneContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GenericRepository(FalconOneContext falconOneContext,
            IHttpContextAccessor httpContextAccessor)
        {
            _falconOneContext = falconOneContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity is ITrackableEntity)
            {
                (entity as ITrackableEntity).CreatedOn = DateTime.UtcNow;
            }

            if (entity is IMultiTenantEntity)
            {
                (entity as IMultiTenantEntity).TenantId = !GetTenantId().Equals(Guid.Empty) ? GetTenantId() : null;
            }

            var query = await _falconOneContext.Set<T>().AddAsync(entity);

            return query.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            return await Task.FromResult(_falconOneContext.Set<T>().Remove(entity).Entity);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _falconOneContext.Set<T>().FindAsync(id);
        }

        public async Task<T> QueryAsync(Expression<Func<T, bool>> expression)
        {
            return await _falconOneContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await _falconOneContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _falconOneContext.Set<T>().ToListAsync();
        }

        //public async Task<IEnumerable<T>> GetAllAsync(PageParams pageParams)
        //{
        //    return await _falconOneContext.Set<T>()
        //                                  .Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
        //                                  .Take(pageParams.PageSize)
        //                                  .ToListAsync();
        //}

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity is ITrackableEntity)
            {
                (entity as ITrackableEntity).ModifiedOn = DateTime.UtcNow;
            }
            return _falconOneContext.Set<T>().Update(entity).Entity;
        }

        public IQueryable<T> GetQuery()
        {
            return _falconOneContext.Set<T>().AsQueryable();
        }

        public async Task<PagedList<T>> GetAllAsync(PageParams pageParams)
        {
            var query = _falconOneContext.Set<T>().AsQueryable();

            return new PagedList<T>(query, pageParams.PageIndex, pageParams.PageSize);
        }

        #region Private methods
        private Guid GetTenantId()
        {
            var val = _httpContextAccessor.HttpContext.Request.Headers["TenantHostHeader"];

            Guid tenantId;
            Guid.TryParse(val, out tenantId);

            return tenantId;
        }
        #endregion
    }
}
