using FinancialControl.Domain.Events.Expensies;
using FinancialControl.Queries.Data;
using FinancialControl.Queries.Models.Expensies;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Queries.DomainEventHandlers.ExpenseCreated
{
    public class ExpenseRemovedDomainEventHandler : INotificationHandler<ExpenseRemovedDomainEvent>
    {
        private readonly ReadDbContext _readDbContext;

        public ExpenseRemovedDomainEventHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task Handle(ExpenseRemovedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _readDbContext.Expensies.DeleteOneAsync(Builders<ExpenseModel>.Filter.Eq(x => x.Id, notification.Id));
        }
    }
}