using MediatR;

namespace FinancialControl.Application.Commands.Expensies.CreateExpense
{
    public class CreateExpenseCommand : IRequest<CreateExpenseCommandResult>
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}