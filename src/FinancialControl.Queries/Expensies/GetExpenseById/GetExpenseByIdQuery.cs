using MediatR;
using System;

namespace FinancialControl.Queries.Expensies.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<GetExpenseByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}