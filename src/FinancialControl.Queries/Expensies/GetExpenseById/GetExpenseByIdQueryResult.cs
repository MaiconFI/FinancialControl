using FinancialControl.Queries.Models.Expensies;

namespace FinancialControl.Queries.Expensies.GetExpenseById
{
    public class GetExpenseByIdQueryResult
    {
        public GetExpenseByIdQueryResult()
        {
        }

        public ExpenseModel Expense { get; set; }
    }
}