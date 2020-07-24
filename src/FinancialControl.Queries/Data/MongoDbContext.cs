using MongoDB.Driver;

namespace FinancialControl.Queries.Data
{
    public abstract class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _mongoClient;

        protected MongoDbContext(IMongoConfiguration mongoConfiguration)
        {
            _mongoClient = new MongoClient(mongoConfiguration.ConnectionString);
            _database = _mongoClient.GetDatabase(mongoConfiguration.DatabaseName);
        }

        protected IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }
    }
}