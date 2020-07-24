using AutoMapper;
using FinancialControl.Domain.Events.Expensies;
using FinancialControl.Queries.Data;
using FinancialControl.Queries.Models.Expensies;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Queries.DomainEventHandlers.ExpenseCreated
{
    public class ExpenseCreatedDomainEventHandler : INotificationHandler<ExpenseCreatedDomainEvent>
    {
        private readonly IMapper _mapper;
        private readonly ReadDbContext _readDbContext;

        public ExpenseCreatedDomainEventHandler(IMapper mapper, ReadDbContext readDbContext)
        {
            _mapper = mapper;
            _readDbContext = readDbContext;
        }

        public async Task Handle(ExpenseCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _readDbContext.Expensies.InsertOneAsync(_mapper.Map<ExpenseModel>(notification));
        }
    }
}