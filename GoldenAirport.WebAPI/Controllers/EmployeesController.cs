using GoldenAirport.Application.Employees.Commands.Create;
using GoldenAirport.Application.Employees.Commands.Delete;
using GoldenAirport.Application.Employees.Commands.Edit;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Users.Commands.Delete;
using GoldenAirport.Application.Users.Commands.EditUser;
using GoldenAirport.Application.Users.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeesController : BaseController<EmployeesController>
    {

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreateEmployeeCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(string Id, [FromForm] UpdateEmployeeDto dto)
        {


            var command = new EditEmployeeCommand
            {
                Id = Id,
                UserName = dto.UserName,
                Email = dto.Email,
                NewPassword = dto.NewPassword,
                CurrentPassword = dto.CurrentPassword,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                UserType = dto.UserType,
                ProfilePicture = dto.ProfilePicture,
                ServiceFees = dto.ServiceFees,
                IsActive = dto.IsActive,
                AgentCode = dto.AgentCode,
                Balance = dto.Balance,  
                DailyGoal = dto.DailyGoal,  
                PaymentMethod = dto.PaymentMethod,
                CurrentUserId = CurrentUserId
            };
            var validationResults = await new EditEmployeeCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(string Id)
        {
            var command = new DeleteEmployeeCommand
            {
                Id = Id,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
