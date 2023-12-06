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

        [HttpGet("fetch")]
        public async Task<IActionResult> GetAllEmployees([FromQuery] string? keySearch, DateTime? DateFrom, DateTime? DateTo,  int pageNumber = 1)
        {
            var query = new GetAllEmployeeQuery { PageNumber = pageNumber, SearchKey = keySearch, DateFrom = DateFrom , DateTo = DateTo };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpGet("fetch1")]
        public async Task<IActionResult> GetAdminDetails(string Id)
        {
            var query = new GetEmployeeByIdQuery { Id = Id };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(string Id, [FromForm] UpdateEmployeeDto dto)
        {

            var command = new EditEmployeeCommand
            {
                Id = Id,
                IsActive = dto.IsActive,
                ServiceFees = dto.ServiceFees,                
                CurrentUserId = CurrentUserId
            };
            var validationResults = await new EditEmployeeCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        //[HttpDelete("Delete")]
        //public async Task<IActionResult> DeleteEmployee(string Id)
        //{
        //    var command = new DeleteEmployeeCommand
        //    {
        //        Id = Id,
        //        CurrentUserId = CurrentUserId
        //    };

        //    var result = await Mediator.Send(command);

        //    return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        //}
    }
}
