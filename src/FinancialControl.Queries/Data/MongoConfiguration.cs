using Microsoft.Extensions.Configuration;

namespace FinancialControl.Queries.Data
{
    public class MongoConfiguration : IMongoConfiguration
    {
        private readonly IConfiguration _configuration;

        public MongoConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString() => _configuration["MongoDb:ConnectionString"];

        public string GetDatabaseName() => _configuration["MongoDb:DatabaseName"];
    }
}