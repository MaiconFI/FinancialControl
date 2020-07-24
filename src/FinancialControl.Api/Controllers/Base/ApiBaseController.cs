using FinancialControl.Application.Commands.Base;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.Api.Controllers.Base
{
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected IActionResult TratarRetorno(RequestResult requestResult)
            => requestResult.Valid
                ? Ok(requestResult)
                : (IActionResult)BadRequest(requestResult);
    }
}