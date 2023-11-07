using GoldenAirport.Application.AdminDetails.Commands;
using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.AdminDetails.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdminDetailsController : BaseController<AdminDetailsController>
    {
        public AdminDetailsController() { }

        [HttpGet("feach1")]
        public async Task<IActionResult> GetAdminDetails(string UserId)
        {
            var query = new GetAdminDetailsQuery { UserId = UserId };
            var result =  await Mediator.Send(query);
            return result.Error != null ? BadRequest(result) : Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(string UserId, [FromForm] AdminDetailsDto dto)
        {

            var command = new UpdateAdminDetailsCommand
            {
                UserId = UserId,
                ServiceFees = dto.ServiceFees,
                TaxValue = dto.TaxValue,
                BookingTime = dto.BookingTime,
                PrivacyPolicyAndTerms = dto.PrivacyPolicyAndTerms,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return result.Error != null ? BadRequest(result) : Ok(result);
        }

    }
}
