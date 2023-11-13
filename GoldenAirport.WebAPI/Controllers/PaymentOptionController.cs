using GoldenAirport.Application.Employees.Commands.Edit;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PaymentOptionController : BaseController<PaymentOptionController>
    {
        public PaymentOptionController() { }


        [HttpGet("fetch")]
        public async Task<IActionResult> GetPaymentOption(string EmployeeId)
        {
            var query = new GetPaymentOptionQuery
            {
                EmployeeId = EmployeeId
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(string Id, [FromForm] UpdatePaymentOptionDto dto)
        {

            var command = new EditPaymentOptionCommand
            {
                EmployeeId = Id,
                paymentOptionIds = dto.paymentOptionIds,
               //Status = dto.Status,
            };

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
