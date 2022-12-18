using System.Linq.Expressions;
using Utilities.Helpers;

namespace FalconOne.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync(PageParams pageParams);
    }
}
