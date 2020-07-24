using AutoMapper;
using FinancialControl.Application.Commands.Expensies.UpdateExpense;
using FinancialControl.Domain.Models.Expensies;

namespace FinancialControl.Application.Mappers
{
    public class ExpenseToUpdateExpenseCommandResultConverter : ITypeConverter<Expense, UpdateExpenseCommandResult>
    {
        public UpdateExpenseCommandResult Convert(Expense source, UpdateExpenseCommandResult destination, ResolutionContext context)
        {
            var result = new UpdateExpenseCommandResult();
            result.AddError(source.Errors);

            return result;
        }
    }
}