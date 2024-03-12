using System.Linq.Expressions;

namespace FalconOne.Models.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken);
        Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        void RemoveAsync(T entity);
        void RemoveRangeAsync(List<T> entities);
        void UpdateAsync(T entity);
        void UpdateRangeAsync(List<T> entities);
    }
}
