using GoldenAirport.Application.Flights.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FlightsController : BaseController<FlightsController>
    {

        [HttpGet("fetchFlight")]
        public async Task<IActionResult> Flights()
        {
            var query = new GetFlightQuery();
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("BookingFlight")]
        public async Task<IActionResult> BookingFlight(BookingFlightCommand Command)
        {
            var result = await Mediator.Send(Command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
