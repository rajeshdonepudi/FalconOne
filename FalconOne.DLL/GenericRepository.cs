using FalconOne.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Utilities.Helpers;

namespace FalconOne.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FalconOneContext _falconOneContext;

        public GenericRepository(FalconOneContext falconOneContext)
        {
            _falconOneContext = falconOneContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            return (await _falconOneContext.Set<T>().AddAsync(entity)).Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            return await Task.FromResult(_falconOneContext.Set<T>().Remove(entity).Entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _falconOneContext.Set<T>().FindAsync(id);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _falconOneContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _falconOneContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(PageParams pageParams)
        {
            return await _falconOneContext.Set<T>()
                                          .Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                                          .Take(pageParams.PageSize)
                                          .ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return _falconOneContext.Set<T>().Update(entity).Entity;
        }
    }
}
