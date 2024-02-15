using GoldenAirport.Application.Cities.Commands.Create;
using GoldenAirport.Application.Cities.Commands.Delete;
using GoldenAirport.Application.Cities.Commands.Edit;
using GoldenAirport.Application.Cities.Dtos;
using GoldenAirport.Application.Cities.Queries;
using GoldenAirport.Application.Flights.Commands;
using GoldenAirport.Application.Flights.ThirdParty;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CitiesController : BaseController<CitiesController>
    {
        public CitiesController() 
        {

        }

        [HttpGet("fetch")]
        public async Task<IActionResult> GetCities([FromQuery] int pageNumber)
        {
            var query = new GetCitiesQuery { PageNumber = pageNumber };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
        
        [HttpGet("fetch1")]
        public async Task<IActionResult> GetCitiesByCountryId([FromQuery] int CountryId)
        {
            var query = new GetCitiesByCountryIdQuery { CountryId = CountryId };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCityCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdateCityDto dto)
        {
            var editCity = new EditCityCommand
            {
                Id = Id,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                CountryId = dto.CountryId,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(editCity);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleteCity = new DeleteCityCommand { Id = Id };
            var result = await Mediator.Send(deleteCity);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpGet("fetchFlight")]
        public async Task<IActionResult> Flights()
        {
            var query = new CreateFlightCommand();
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpGet("BookingFlight")]
        public async Task<IActionResult> BookingFlight()
        {
            var query = new BookingFlightCommand();
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}

