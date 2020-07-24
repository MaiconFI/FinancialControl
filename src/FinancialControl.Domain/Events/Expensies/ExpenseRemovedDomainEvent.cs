using System;

namespace FinancialControl.Domain.Events.Expensies
{
    public class ExpenseRemovedDomainEvent : DomainEvent
    {
        public ExpenseRemovedDomainEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}