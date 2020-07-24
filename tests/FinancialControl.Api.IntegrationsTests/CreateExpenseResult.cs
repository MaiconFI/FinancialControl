using System;

namespace FinancialControl.Api.IntegrationsTests
{
    public class CreateExpenseResult
    {
        public Guid Id { get; set; }

        public bool Valid { get; set; }
    }
}