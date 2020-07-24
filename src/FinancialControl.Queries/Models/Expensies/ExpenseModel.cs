using FinancialControl.Queries.Base;
using System;

namespace FinancialControl.Queries.Models.Expensies
{
    public class ExpenseModel : Model
    {
        public ExpenseModel(Guid id, string category, DateTime creationDate, string description, decimal value)
            : base(id)
        {
            Category = category;
            CreationDate = creationDate;
            Description = description;
            Value = value;
        }

        public string Category { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
    }
}