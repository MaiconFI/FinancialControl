using FinancialControl.Queries.Models.Expensies;
using MongoDB.Driver;

namespace FinancialControl.Queries.Data
{
    public class ReadDbContext : MongoDbContext
    {
        public ReadDbContext(IMongoConfiguration mongoConfiguration)
            : base(mongoConfiguration)
        {
        }

        internal IMongoCollection<ExpenseModel> Expensies => GetCollection<ExpenseModel>();
    }
}