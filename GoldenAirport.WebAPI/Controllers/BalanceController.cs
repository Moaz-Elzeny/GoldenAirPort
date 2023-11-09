using GoldenAirport.Application.Employees.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : BaseController<BalanceController>
    {

        [HttpPost("Balance")]
        public async Task<IActionResult> CreateBalance([FromForm] CreateBalanceCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
