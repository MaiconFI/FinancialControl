using FinancialControl.Domain.Repositories;
using FinancialControl.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialControl.Infrastructure.Data.IoC
{
    public static class IoCData
    {
        public static void AddData(this IServiceCollection services)
        {
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
        }
    }
}