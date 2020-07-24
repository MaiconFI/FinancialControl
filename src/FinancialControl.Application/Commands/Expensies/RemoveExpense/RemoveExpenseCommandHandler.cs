using FinancialControl.Domain.Events.Expensies;
using FinancialControl.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Application.Commands.Expensies.RemoveExpense
{
    public class RemoveExpenseCommandHandler : IRequestHandler<RemoveExpenseCommand, RemoveExpenseCommandResult>
    {
        private readonly IExpenseRepository _expenseRepository;

        public RemoveExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<RemoveExpenseCommandResult> Handle(RemoveExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetAsync(request.Id, cancellationToken);
            if (expense is null)
            {
                var result = new RemoveExpenseCommandResult();
                result.AddError("The expense doesn't exists.");
                return result;
            }

            _expenseRepository.Remove(expense);
            expense.AddDomainEvent(new ExpenseRemovedDomainEvent(expense.Id));

            await _expenseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new RemoveExpenseCommandResult();
        }
    }
}