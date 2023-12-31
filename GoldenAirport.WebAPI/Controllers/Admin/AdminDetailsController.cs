﻿using GoldenAirport.Application.AdminDetails.Commands;
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

        [HttpGet("fetch1")]
        public async Task<IActionResult> GetAdminDetails(string? UserId)
        {
            var query = new GetAdminDetailsQuery { UserId = UserId ?? CurrentUserId };
            var result =  await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(string UserId, UpdateAdminDetailsDto dto)
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

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
