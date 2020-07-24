using FinancialControl.Queries.Data;
using FinancialControl.Queries.Models.Expensies;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Queries.Expensies.GetExpenseById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, GetExpenseByIdQueryResult>
    {
        private readonly ReadDbContext _readDbContext;

        public GetExpenseByIdQueryHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task<GetExpenseByIdQueryResult> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            return new GetExpenseByIdQueryResult()
            {
                Expense = await _readDbContext.Expensies.Find(Builders<ExpenseModel>.Filter.Eq(x => x.Id, request.Id)).FirstOrDefaultAsync()
            };
        }
    }
}