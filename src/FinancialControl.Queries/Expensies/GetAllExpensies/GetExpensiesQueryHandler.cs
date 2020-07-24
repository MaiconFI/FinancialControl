using FinancialControl.Queries.Data;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Queries
{
    public class GetExpensiesQueryHandler : IRequestHandler<GetExpensiesQuery, GetExpensiesQueryResult>
    {
        private readonly ReadDbContext _readDbContext;

        public GetExpensiesQueryHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task<GetExpensiesQueryResult> Handle(GetExpensiesQuery request, CancellationToken cancellationToken)
        {
            return new GetExpensiesQueryResult()
            {
                Expensies = await _readDbContext.Expensies.Find(_ => true).ToListAsync()
            };
        }
    }
}