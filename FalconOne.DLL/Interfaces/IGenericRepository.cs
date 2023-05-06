using System.Linq.Expressions;
using Utilities.Helpers;

namespace FalconOne.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> FindAsync(Guid id);
        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entities);
        Task<T> QueryAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> QueryAllAsync(Expression<Func<T, bool>> expression);
        Task<PagedList<T>> GetAllAsync(PageParams pageParams);
        IQueryable<T> GetQueryable();
    }
}
