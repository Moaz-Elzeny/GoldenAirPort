using GoldenAirport.Application.AdminDetails.Queries;
using GoldenAirport.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeeHomeController : BaseController<EmployeeHomeController>
    {
        public EmployeeHomeController() { }

        [HttpGet("EmployeeHome")]
        public async Task<IActionResult> GetAdminDetails()
        {

            var query = new EmployeeHomeQuery { UserId = CurrentUserId };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
