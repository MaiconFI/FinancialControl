using FinancialControl.Application.Commands.Base;
using System;

namespace FinancialControl.Application.Commands.Expensies.CreateExpense
{
    public class CreateExpenseCommandResult : RequestResult
    {
        public CreateExpenseCommandResult(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}