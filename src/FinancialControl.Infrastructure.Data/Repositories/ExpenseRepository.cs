using FinancialControl.Domain.Base;
using FinancialControl.Domain.Models.Expensies;
using FinancialControl.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Infrastructure.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinancialControlContext _context;

        public ExpenseRepository(FinancialControlContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Expense Add(Expense expense)
        {
            return _context.Add(expense).Entity;
        }

        public async Task<Expense> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Expensies.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public void Remove(Expense expense)
        {
            _context.Expensies.Remove(expense);
        }

        public void Update(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
        }
    }
}