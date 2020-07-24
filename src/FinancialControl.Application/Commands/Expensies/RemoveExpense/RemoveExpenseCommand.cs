using MediatR;
using System;

namespace FinancialControl.Application.Commands.Expensies.RemoveExpense
{
    public class RemoveExpenseCommand : IRequest<RemoveExpenseCommandResult>
    {
        public Guid Id { get; set; }
    }
}