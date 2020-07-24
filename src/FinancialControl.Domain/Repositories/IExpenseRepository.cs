using FinancialControl.Domain.Base;
using FinancialControl.Domain.Models.Expensies;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Repositories
{
    public interface IExpenseRepository : IRepository
    {
        Expense Add(Expense expense);

        Task<Expense> GetAsync(Guid id, CancellationToken cancellationToken);

        void Remove(Expense expense);

        void Update(Expense expense);
    }
}