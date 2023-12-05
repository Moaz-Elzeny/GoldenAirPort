using GoldenAirport.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StatementsController : BaseController<StatementsController>
    {
        public StatementsController() { }

        [HttpGet("fetch")] 
        public async Task<IActionResult> GetStatement(string EmployeeId , int PageNumber = 1)
        {
            var query = new GetStatementQuery{PageNumber = PageNumber , EmployeeId = EmployeeId};
            var result = await Mediator.Send(query);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
