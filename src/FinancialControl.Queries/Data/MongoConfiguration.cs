namespace FinancialControl.Queries.Data
{
    public class MongoConfiguration : IMongoConfiguration
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}