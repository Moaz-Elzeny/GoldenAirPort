using GoldenAirport.Application.Cities.Commands.Create;
using GoldenAirport.Application.Cities.Commands.Delete;
using GoldenAirport.Application.Cities.Commands.Edit;
using GoldenAirport.Application.Cities.Dtos;
using GoldenAirport.Application.Cities.Queries;
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

        [HttpGet("feach")]
        public async Task<IActionResult> GetCities([FromQuery] int pageNumber)
        {
            var query = new GetCitiesQuery { PageNumber = pageNumber };
            var result = await Mediator.Send(query);
            return result.Error != null ? BadRequest(result) : Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCityCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(command);
            return result.Error != null ? BadRequest(result) : Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromHeader] int Id, [FromBody] UpdateCityDto dto)
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
            return result.Error != null ? BadRequest(result) : Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleteCity = new DeleteCityCommand { Id = Id };
            var result = await Mediator.Send(deleteCity);

            return result.Error != null ? BadRequest(result) : Ok(result);
        }
    }
}

