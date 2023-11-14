using GoldenAirport.Application.Employees.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StatementsController : BaseController<StatementsController>
    {
        public StatementsController() { }

        [HttpGet("fetch")] 
        public async Task<IActionResult> GetStatement(string Id)
        {
            var dto = new  GetStatementDto();
            return Ok(dto);
        }
    }
}
