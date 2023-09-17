using System.Linq.Expressions;

namespace MongoDbIntegration.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
