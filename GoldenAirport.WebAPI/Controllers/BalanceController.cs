using GoldenAirport.Application.Employees.Commands.Create;
using GoldenAirport.Application.Employees.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BalanceController : BaseController<BalanceController>
    {

        [HttpPut("Balance")]
        public async Task<IActionResult> CreateBalance(string Id, BalanceDto dto)
        {
            var command = new CreateBalanceCommand
            {
                EmployeeId = Id,
                CurrentUserId = CurrentUserId,
                AddBalance = dto.AddBalance,
                RebateBalance = dto.RebateBalance,

            };
            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
