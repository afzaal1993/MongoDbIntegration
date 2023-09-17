using MongoDB.Driver;
using System.Linq.Expressions;

namespace MongoDbIntegration.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        public GenericRepository(IMongoClient mongoClient, IConfiguration configuration)
        {
            var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;
            var collectionName = configuration.GetSection("CollectionSettings:"+typeof(T).Name + "CollectionName").Value;
            var database = mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }
        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
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

        public Task<T> GetOneAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
