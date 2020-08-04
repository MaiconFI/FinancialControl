using MongoDB.Driver;

namespace FinancialControl.Queries.Data
{
    public abstract class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _mongoClient;

        protected MongoDbContext(IMongoConfiguration mongoConfiguration)
        {
            _mongoClient = new MongoClient(mongoConfiguration.GetConnectionString());
            _database = _mongoClient.GetDatabase(mongoConfiguration.GetDatabaseName());
        }

        protected IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }
    }
}