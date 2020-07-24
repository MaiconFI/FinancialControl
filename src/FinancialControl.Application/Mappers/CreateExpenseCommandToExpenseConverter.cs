using AutoMapper;
using FinancialControl.Application.Commands.Expensies.CreateExpense;
using FinancialControl.Domain.Models.Expensies;

namespace FinancialControl.Application.Mappers
{
    public class CreateExpenseCommandToExpenseConverter : ITypeConverter<CreateExpenseCommand, Expense>
    {
        public Expense Convert(CreateExpenseCommand source, Expense destination, ResolutionContext context)
        {
            var builder = new ExpenseBuilder()
                .WithCategory(source.Category)
                .WithDescription(source.Description)
                .WithValue(source.Value);

            return builder.Build();
        }
    }
}