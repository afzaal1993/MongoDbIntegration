using MongoDbIntegration.Models;
using System.Linq.Expressions;

namespace MongoDbIntegration.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<ApiResponse<T>> CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
        Task<ApiResponse<T>> GetOneAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
