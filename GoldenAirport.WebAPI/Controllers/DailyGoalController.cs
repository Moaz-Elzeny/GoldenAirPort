using GoldenAirport.Application.Employees.Commands.Edit;
using GoldenAirport.Application.Employees.Commands.Edit.Actions;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Employees.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DailyGoalController : BaseController<DailyGoalController>
    {
        public DailyGoalController() { }


        [HttpGet("fetch")]
        public async Task<IActionResult> GetDailyGoal()
        {
            var query = new GetDailyGoalQuery();
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(string Id, [FromForm] UpdateDailyDto dto)
        {

            var command = new EditDailyGoalCommand
            {
                EmployeeId = Id,
                Target = dto.Target,
            };

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
