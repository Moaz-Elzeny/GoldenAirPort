using GoldenAirport.Application.Boards.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StatisticsController : BaseController<StatisticsController>
    {
        public StatisticsController() { }

        [HttpGet("Statistics")]
        public async Task<IActionResult> CalculateStatisticsPerMonth([FromQuery]CalculateStatisticsPerMonthCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
