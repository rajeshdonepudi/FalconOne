using System.Linq.Expressions;

namespace FalconOne.DLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> FindAsync(Expression<Func<T>> expression);
    }
}
