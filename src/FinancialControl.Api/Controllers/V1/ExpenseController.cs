using FinancialControl.Application.Commands.Expensies.CreateExpense;
using FinancialControl.Application.Commands.Expensies.RemoveExpense;
using FinancialControl.Application.Commands.Expensies.UpdateExpense;
using FinancialControl.Queries;
using FinancialControl.Queries.Expensies.GetExpenseById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/expense")]
    [ApiVersion("1")]
    public class ExpenseController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] RemoveExpenseCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetExpensiesQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetExpenseByIdQuery() { Id = id }, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateExpenseCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateExpenseCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}