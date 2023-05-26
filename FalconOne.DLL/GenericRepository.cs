using FalconOne.DAL.Interfaces;
using FalconOne.Helpers.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity is ITrackableEntity)
            {
                (entity as ITrackableEntity).ModifiedOn = DateTime.UtcNow;
            }
            return _falconOneContext.Set<T>().Update(entity).Entity;
        }

        public IQueryable<T> GetQueryable()
        {
            return _falconOneContext.Set<T>().AsQueryable();
        }

        public async Task<PagedList<T>> GetAllAsync(PageParams pageParams)
        {
            var query = _falconOneContext.Set<T>().AsQueryable();

            return await Task.FromResult(new PagedList<T>(query, pageParams.PageIndex, pageParams.PageSize));
        }

        #region Private methods
        public async Task<IEnumerable<T>> QueryAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _falconOneContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task UpdateRangeAsync(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is ITrackableEntity)
                {
                    (entity as ITrackableEntity).ModifiedOn = DateTime.UtcNow;
                }
            }
            _falconOneContext.Set<T>().UpdateRange(entities);
        }
        #endregion
    }
}
