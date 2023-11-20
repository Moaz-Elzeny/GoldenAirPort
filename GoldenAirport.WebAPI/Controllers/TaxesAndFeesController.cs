using GoldenAirport.Application.Employees.Queries;
using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TaxesAndFeesController : BaseController<TaxesAndFeesController>
    {
        public TaxesAndFeesController() { }

        [HttpGet("fetch1")]
        public async Task<IActionResult> GetTaxesAndFees([FromQuery] string Id , UserType userType)
        {
            var query = new GetTaxesAndFeesQuery { Id = Id , UserType = userType };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
