using FinancialControl.Domain.Models.Expensies;
using System;

namespace FinancialControl.Domain.Events.Expensies
{
    public class ExpenseUpdatedDomainEvent : DomainEvent
    {
        public ExpenseUpdatedDomainEvent(Expense expense)
        {
            Category = expense.Category;
            Id = expense.Id;
            Description = expense.Description;
            Value = expense.Value;
        }

        public string Category { get; private set; }
        public string Description { get; private set; }
        public Guid Id { get; private set; }
        public decimal Value { get; private set; }
    }
}