using FinancialControl.Domain.Models.Expensies;
using System;

namespace FinancialControl.Domain.Events.Expensies
{
    public class ExpenseCreatedDomainEvent : DomainEvent
    {
        public ExpenseCreatedDomainEvent(Expense expense)
        {
            Category = expense.Category;
            CreationDate = expense.CreationDate;
            Description = expense.Description;
            Id = expense.Id;
            Value = expense.Value;
        }

        public string Category { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Description { get; private set; }
        public Guid Id { get; private set; }
        public decimal Value { get; private set; }
    }
}