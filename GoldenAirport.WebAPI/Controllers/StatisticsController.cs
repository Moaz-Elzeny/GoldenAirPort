using GoldenAirport.Application.Boards.Commands;
using GoldenAirport.Application.Boards.Queries;
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

        
        [HttpGet("GetChartsStatistics")]
        public async Task<IActionResult> GetChartsStatistics([FromQuery] GetChartsStatisticsQuery query)
        {
            query.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
        
        [HttpGet("GetCountStatistics")]
        public async Task<IActionResult> GetCountStatistics([FromQuery] GetCountStatisticsQuery query)
        {
            query.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
        
        [HttpGet("GetPercentageStatistics")]
        public async Task<IActionResult> GetPercentageStatistics([FromQuery] GetPercentageStatisticsQuery query)
        {
            query.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpGet("Airports")]
        public async Task<IActionResult> GetAirports()
        {
            var command = new GetAirportsQuery();
            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
