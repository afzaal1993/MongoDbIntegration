using MongoDB.Driver;
using MongoDbIntegration.Models;

namespace MongoDbIntegration.Repositories
{
    public class CategoryRepo : GenericRepository<Category>, ICategory
    {
        public CategoryRepo(IMongoClient mongoClient, IConfiguration configuration) : base(mongoClient, configuration)
        {
        }
    }
}
