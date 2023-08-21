using GoldenAirport.Application.Countries.Commands.Create;
using GoldenAirport.Application.Countries.Commands.Delete;
using GoldenAirport.Application.Countries.Commands.Edit;
using GoldenAirport.Application.Countries.Dtos;
using GoldenAirport.Application.Countries.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetCountries([FromQuery]int pageNumber)
        {
            var query = new GetCountriesQuery { PageNumber = pageNumber };
            var result = await Mediator.Send(query);
            return result.Errors != null ? BadRequest(result.Errors) : Ok(result.Data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CreateCountryCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(command);
            return result.Errors != null ? BadRequest(result.Errors) : Ok(result.Data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromHeader]int Id, [FromBody]UpdateCountryDto dto )
        {
            var country = new EditCountryCommand
            { 
                Id= Id,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                CurrentUserId = CurrentUserId
            }; 

            var result = await Mediator.Send(country);
            return result.Errors != null ? BadRequest(result.Errors) : Ok(result.Data);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var country = new DeleteCountryCommand { Id = Id };
            var result = await Mediator.Send(country);

            return result.Errors != null ? BadRequest(result.Errors) :  Ok(result.Data);
        }
    }
}
