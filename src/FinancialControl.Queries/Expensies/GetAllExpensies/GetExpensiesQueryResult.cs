using FinancialControl.Queries.Models.Expensies;
using System.Collections.Generic;

namespace FinancialControl.Queries
{
    public class GetExpensiesQueryResult
    {
        public IEnumerable<ExpenseModel> Expensies { get; set; }
    }
}