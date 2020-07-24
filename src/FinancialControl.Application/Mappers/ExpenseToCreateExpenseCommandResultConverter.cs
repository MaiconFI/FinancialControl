using AutoMapper;
using FinancialControl.Application.Commands.Expensies.CreateExpense;
using FinancialControl.Domain.Models.Expensies;

namespace FinancialControl.Application.Mappers
{
    public class ExpenseToCreateExpenseCommandResultConverter : ITypeConverter<Expense, CreateExpenseCommandResult>
    {
        public CreateExpenseCommandResult Convert(Expense source, CreateExpenseCommandResult destination, ResolutionContext context)
        {
            var result = new CreateExpenseCommandResult(source.Id);
            result.AddError(source.Errors);

            return result;
        }
    }
}