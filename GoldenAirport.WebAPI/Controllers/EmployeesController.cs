using GoldenAirport.Application.Employees.Commands.Create;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<EmployeesController>
    {
        private readonly UserManager<AppUser> _userManager;
        public EmployeesController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

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
    }
}
