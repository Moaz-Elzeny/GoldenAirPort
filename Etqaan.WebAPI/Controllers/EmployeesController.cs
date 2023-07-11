using Etqaan.Application.Employees.Commands.CreateEmployee;
using Etqaan.Application.Employees.Commands.Delete;
using Etqaan.Application.Employees.Commands.EditEmployee;
using Etqaan.Application.Employees.DTOs;
using Etqaan.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Etqaan.WebAPI.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeesController : BaseController<EmployeesController>
    {
        public EmployeesController()
        {

        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees(int pageNumber = 1)
        {
            var query = new GetAllEmployeesQuery
            {
                PageNumber = pageNumber,

            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }



        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(string Id, [FromForm] UpdateEmployeeDto dto)
        {
            var command = new EditEmployeeCommand
            {
                EmployeeId = Id,
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                NationalIdNumber = dto.NationalIdNumber,
                Religion = dto.Religion,
                AddressDetails = dto.AddressDetails,
                ProfilePicture = dto.ProfilePicture,
                UserType = dto.UserType,
                NationalityId = dto.NationalityId,
                JobTitle = dto.JobTitle,
                YearsOfExperience = dto.YearsOfExperience,
                JobType = dto.JobType,
                Salary = dto.Salary,
                BankId = dto.BankId,
                BankAccountNumber = dto.BankAccountNumber,
                IBAN = dto.IBAN,
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
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var command = new DeleteEmployeeCommand
            {
                EmployeeId = id,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }


    }
}
