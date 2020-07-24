using AutoMapper;
using FinancialControl.Domain.Events.Expensies;
using FinancialControl.Queries.Models.Expensies;

namespace FinancialControl.Queries.Mappers
{
    public class ExpenseCreatedDomainEventToExpenseModelConverter : ITypeConverter<ExpenseCreatedDomainEvent, ExpenseModel>
    {
        public ExpenseModel Convert(ExpenseCreatedDomainEvent source, ExpenseModel destination, ResolutionContext context)
        {
            return new ExpenseModel(source.Id, source.Category, source.CreationDate, source.Description, source.Value);
        }
    }
}