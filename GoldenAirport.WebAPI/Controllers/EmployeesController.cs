using GoldenAirport.Application.Employees.Commands.Create;
using GoldenAirport.Application.Employees.Commands.Delete;
using GoldenAirport.Application.Employees.Commands.Edit;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeesController : BaseController<EmployeesController>
    {

        [HttpGet("feach")]
        public async Task<IActionResult> GetAllEmployees([FromQuery]int pageNumber, string? keySerch)
        {
            var query = new GetAllEmployeeQuery{PageNumber = pageNumber, SearchKey = keySerch};
            var result = await Mediator.Send(query);
            return result.Errors != null ? BadRequest(result) : Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreateEmployeeCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return result.Errors != null ? BadRequest(result) : Ok(result);
        }

        [HttpPost("CreateBalance")]
        public async Task<IActionResult> CreateBalance([FromForm] CreateBalanceCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(command);
            return result.Errors != null ? BadRequest(result) : Ok(result);
        }

            [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(string Id, [FromForm] UpdateEmployeeDto dto)
        {

            var command = new EditEmployeeCommand
            {
                Id = Id,               
                //AppUserId = dto.AppUserId,
                IsActive = dto.IsActive,
                AgentCode = dto.AgentCode,
                Date = dto.Date,
                //Balance = dto.Balance,  
                //DailyGoal = dto.DailyGoal,  
                PaymentMethod = dto.PaymentMethod,
                CurrentUserId = CurrentUserId
            };
            var validationResults = await new EditEmployeeCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return result.Errors != null ? BadRequest(result) : Ok(result);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployee(string Id)
        {
            var command = new DeleteEmployeeCommand
            {
                Id = Id,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return result.Errors != null ? BadRequest(result) : Ok(result);
        }
    }
}
