using AutoMapper;
using FinancialControl.Domain.Events.Expensies;
using FinancialControl.Domain.Models.Expensies;
using FinancialControl.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Application.Commands.Expensies.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, CreateExpenseCommandResult>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<CreateExpenseCommandResult> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = _mapper.Map<Expense>(request);
            if (expense.InValid)
                return _mapper.Map<CreateExpenseCommandResult>(expense);

            _expenseRepository.Add(expense);
            expense.AddDomainEvent(new ExpenseCreatedDomainEvent(expense));

            await _expenseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateExpenseCommandResult>(expense);
        }
    }
}