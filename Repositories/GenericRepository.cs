using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbIntegration.Models;
using System.Linq.Expressions;

namespace MongoDbIntegration.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        public GenericRepository(IMongoClient mongoClient, IConfiguration configuration)
        {
            var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;
            var collectionName = configuration.GetSection("CollectionSettings:" + typeof(T).Name + "CollectionName").Value;
            var database = mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }
        public async Task<ApiResponse<T>> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return ApiResponse<T>.Success(entity);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();            
        }

        public async Task<ApiResponse<T>> GetOneAsync(Expression<Func<T, bool>> filter)
        {
            T result = await _collection.Find(filter).FirstOrDefaultAsync();
            if (result != null)
            {
                return ApiResponse<T>.Success(result);
            }
            else
            {
                return ApiResponse<T>.NotFound();
            }
        }

        public Task UpdateAsync(string id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
