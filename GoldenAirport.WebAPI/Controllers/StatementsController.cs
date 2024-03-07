using GoldenAirport.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StatementsController : BaseController<StatementsController>
    {
        public StatementsController() { }

        [HttpGet("fetch")] 
        public async Task<IActionResult> GetStatement(string EmployeeId , DateTime? DateFrom, DateTime? DateTo, int PageNumber = 1)
        {
            var query = new GetStatementQuery{PageNumber = PageNumber , EmployeeId = EmployeeId,  DateFrom = DateFrom, DateTo = DateTo };
            var result = await Mediator.Send(query);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
