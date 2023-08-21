using GoldenAirport.Application.Employees.Commands.Create;
using GoldenAirport.Application.Employees.Queries;
using GoldenAirport.Application.Trips.Commands.Create;
using GoldenAirport.Application.Trips.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TripsController : BaseController<TripsController>
    {
        public TripsController()
        {
        }

        [HttpGet("AllTrips")]
        public async Task<IActionResult> GetAllTrips([FromQuery] int pageNumber, string? keySerch)
        {
            var query = new GetTripsQuery { PageNumber = pageNumber, SearchKey = keySerch };
            var result = await Mediator.Send(query);
            return result.Errors != null ? BadRequest(result.Errors) : Ok(result.Data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]CreateTripCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreateTripCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return result.Errors != null ? BadRequest(result.Errors) : Ok(result.Data);

        }
    }
}
