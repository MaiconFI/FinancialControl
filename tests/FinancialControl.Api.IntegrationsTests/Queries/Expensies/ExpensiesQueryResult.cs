using System.Collections.Generic;

namespace FinancialControl.Api.IntegrationsTests.Queries.Expensies
{
    public class ExpensiesQueryResult
    {
        public IEnumerable<ExpenseResult> Expensies { get; set; }
    }
}