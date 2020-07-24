using System;

namespace FinancialControl.Api.IntegrationsTests.Queries.Expensies
{
    public class ExpenseResult
    {
        public string Category { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public decimal Value { get; set; }
    }
}