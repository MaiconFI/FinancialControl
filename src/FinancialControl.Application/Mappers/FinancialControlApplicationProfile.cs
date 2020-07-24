using AutoMapper;
using FinancialControl.Application.Commands.Expensies.CreateExpense;
using FinancialControl.Application.Commands.Expensies.UpdateExpense;
using FinancialControl.Domain.Models.Expensies;

namespace FinancialControl.Application.Mappers
{
    public class FinancialControlApplicationProfile : Profile
    {
        public FinancialControlApplicationProfile()
        {
            CreateMap<CreateExpenseCommand, Expense>().ConvertUsing<CreateExpenseCommandToExpenseConverter>();
            CreateMap<Expense, CreateExpenseCommandResult>().ConvertUsing<ExpenseToCreateExpenseCommandResultConverter>();
            CreateMap<Expense, UpdateExpenseCommandResult>().ConvertUsing<ExpenseToUpdateExpenseCommandResultConverter>();
        }
    }
}