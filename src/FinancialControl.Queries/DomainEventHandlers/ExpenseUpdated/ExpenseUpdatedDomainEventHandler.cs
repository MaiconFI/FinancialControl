using FinancialControl.Domain.Events.Expensies;
using FinancialControl.Queries.Data;
using FinancialControl.Queries.Models.Expensies;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Queries.DomainEventHandlers.ExpenseCreated
{
    public class ExpenseUpdatedDomainEventHandler : INotificationHandler<ExpenseUpdatedDomainEvent>
    {
        private readonly ReadDbContext _readDbContext;

        public ExpenseUpdatedDomainEventHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task Handle(ExpenseUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var query = Builders<ExpenseModel>.Filter.Eq(x => x.Id, notification.Id);
            var update = Builders<ExpenseModel>.Update
                .Set(x => x.Category, notification.Category)
                .Set(x => x.Description, notification.Description)
                .Set(x => x.Value, notification.Value);

            await _readDbContext.Expensies.UpdateOneAsync(query, update);
        }
    }
}