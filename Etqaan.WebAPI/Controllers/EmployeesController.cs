using Etqaan.Application.Employees.Commands.CreateEmployee;
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

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
