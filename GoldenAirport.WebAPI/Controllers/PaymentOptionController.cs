using GoldenAirport.Application.Employees.Commands.Edit;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Employees.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOptionController : BaseController<PaymentOptionController>
    {
        public PaymentOptionController() { }


        [HttpGet("fetch")]
        public async Task<IActionResult> GetPaymentOption()
        {
            var query = new GetAllEmployeeQuery();
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(string Id, [FromForm] UpdatePaymentOptionDto dto)
        {

            var command = new EditPaymentOptionCommand
            {
                EmployeeId = Id,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
            };

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
