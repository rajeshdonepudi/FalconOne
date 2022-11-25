using FalconOne.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FalconOne.DLL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FalconOneContext _falconOneContext;

        public GenericRepository(FalconOneContext falconOneContext)
        {
            _falconOneContext = falconOneContext;
        }

        public void Add(T entity)
        {
            _falconOneContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _falconOneContext.Set<T>().Remove(entity);
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

        public void Update(T entity)
        {
            _falconOneContext.Set<T>().Update(entity);
        }
    }
}
