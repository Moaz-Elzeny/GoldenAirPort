using GoldenAirport.Application.Employees.Commands.Edit.Actions;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DailyGoalController : BaseController<DailyGoalController>
    {
        public DailyGoalController() { }


        [HttpGet("fetch")]
        public async Task<IActionResult> GetDailyGoal(string Id, int PageNumber = 1)
        {
            var query = new GetDailyGoalQuery 
            {
                EmployeeId = Id,
                PageNumber = PageNumber
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
        
        [HttpGet("GetTarget")]
        public async Task<IActionResult> GetTarget(string Id)
        {
            var query = new GetTargetQuey
            {
                EmployeeId = Id,
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpPut("UpdateTarget")]
        public async Task<IActionResult> UpdateEmployee(string Id, [FromForm] UpdateDailyDto dto)
        {

            var command = new EditDailyGoalCommand
            {
                CurrentUserId = CurrentUserId,
                EmployeeId = Id,
                Target = dto.Target,
            };

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
