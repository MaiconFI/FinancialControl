using AutoMapper;
using FinancialControl.Domain.Events.Expensies;
using FinancialControl.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Application.Commands.Expensies.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, UpdateExpenseCommandResult>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public UpdateExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<UpdateExpenseCommandResult> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetAsync(request.Id, cancellationToken);
            if (expense is null)
            {
                var result = new UpdateExpenseCommandResult();
                result.AddError("Expense not found.");
                return result;
            }

            expense.SetCategory(request.Category);
            expense.SetDescription(request.Description);
            expense.SetValue(request.Value);

            if (expense.InValid)
                return _mapper.Map<UpdateExpenseCommandResult>(expense);

            _expenseRepository.Update(expense);
            expense.AddDomainEvent(new ExpenseUpdatedDomainEvent(expense));

            await _expenseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateExpenseCommandResult>(expense);
        }
    }
}