using AutoMapper;
using FinancialControl.Domain.Events.Expensies;
using FinancialControl.Queries.Mappers;
using FinancialControl.Queries.Models.Expensies;

namespace FinancialControl.Application.Mappers
{
    public class FinancialControlQueriesProfile : Profile
    {
        public FinancialControlQueriesProfile()
        {
            CreateMap<ExpenseCreatedDomainEvent, ExpenseModel>().ConvertUsing<ExpenseCreatedDomainEventToExpenseModelConverter>();
        }
    }
}