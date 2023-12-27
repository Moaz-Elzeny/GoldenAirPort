using GoldenAirport.Application.Countries.Commands.Create;
using GoldenAirport.Application.Countries.Commands.Delete;
using GoldenAirport.Application.Countries.Commands.Edit;
using GoldenAirport.Application.Countries.Dtos;
using GoldenAirport.Application.Countries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CountriesController : BaseController<CountriesController>
    {
        public CountriesController() 
        {

        }

        [HttpGet("fetch")]
        public async Task<IActionResult> GetCountries([FromQuery]int pageNumber)
        {
            var query = new GetCountriesQuery { PageNumber = pageNumber };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]CreateCountryCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int Id, [FromForm]UpdateCountryDto dto )
        {
            var editCountry = new EditCountryCommand
            { 
                Id= Id,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                Code = dto.Code,
                Icon = dto.Icon,
                CurrentUserId = CurrentUserId
            }; 

            var result = await Mediator.Send(editCountry);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleteCountry = new DeleteCountryCommand { Id = Id };
            var result = await Mediator.Send(deleteCountry);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
