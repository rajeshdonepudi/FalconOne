using System.Linq.Expressions;

namespace FalconOne.Models.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        void Update(T entity);
        void UpdateRange(List<T> entities);
    }
}
