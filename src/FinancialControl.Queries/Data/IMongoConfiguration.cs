namespace FinancialControl.Queries.Data
{
    public interface IMongoConfiguration
    {
        string ConnectionString { get; }

        string DatabaseName { get; }
    }
}