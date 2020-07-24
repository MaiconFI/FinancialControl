using MediatR;
using System;

namespace FinancialControl.Application.Commands.Expensies.UpdateExpense
{
    public class UpdateExpenseCommand : IRequest<UpdateExpenseCommandResult>
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public decimal Value { get; set; }
    }
}