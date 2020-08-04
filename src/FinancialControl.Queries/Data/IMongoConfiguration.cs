namespace FinancialControl.Queries.Data
{
    public interface IMongoConfiguration
    {
        string GetConnectionString();

        string GetDatabaseName();
    }
}