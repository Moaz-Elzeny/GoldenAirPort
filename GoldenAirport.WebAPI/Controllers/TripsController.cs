using GoldenAirport.Application.Trips.Commands.Create;
using GoldenAirport.Application.Trips.Commands.Delete;
using GoldenAirport.Application.Trips.Commands.Edit;
using GoldenAirport.Application.Trips.Dtos;
using GoldenAirport.Application.Trips.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TripsController : BaseController<TripsController>
    {
        public TripsController()
        {
        }

        [HttpGet("AllTrips")]
        public async Task<IActionResult> GetAllTrips
            ([FromQuery] int pageNumber,
            int? FromCity,
            [FromQuery] List<int>? ToCity,
            [FromQuery] DateTime? StartingOn,
            int? Guests
            )
        {
            var query = new GetTripsQuery
            { 
                PageNumber = pageNumber, 
                FromCity = FromCity, 
                ToCity = ToCity, 
                StartingOn = StartingOn,
                Guests = Guests
            };
            var result = await Mediator.Send(query);
            return result.Errors != null ? BadRequest(result) : Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]CreateTripCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreateTripCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return result.Errors != null ? BadRequest(result) : Ok(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromHeader] int Id, [FromForm] UpdateTripDto dto)
        {
            var command = new EditTripCommand
            {
                Id = Id,
                StartingDate = dto.StartingDate,
                EndingDate = dto.EndingDate,
                Price = dto.Price,
                PriceLessThan2YearsOld = dto.PriceLessThan2YearsOld,
                PriceLessThan12YearsOld = dto.PriceLessThan12YearsOld,
                Guests = dto.Guests,
                TripHours = dto.TripHours,
                FromCityId = dto.FromCityId,
                ToCitiesIds = dto.ToCitiesIds,
                PaymentMethod = dto.PaymentMethod,
                IsRefundable = dto.IsRefundable,
                CurrentUserId = CurrentUserId
            };

            var validationResults = await new EditTripCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);
            return result.Errors != null ? BadRequest(result) : Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleteTrip = new DeleteTripCommand { Id = Id };
            var result = await Mediator.Send(deleteTrip);

            return result.Errors != null ? BadRequest(result) : Ok(result);
        }
        
        [HttpDelete("DeleteActions")]
        public async Task<IActionResult> DeleteActions(int TripId, int? WhyVisitId, int? WhatIncludedId, int? AccessibilityId, int? RestrictionId)
        {
            var deleteTripActios = new DeleteActionsInTripCommand 
            { 
                TripId = TripId,
                WhyVisitId = WhyVisitId,
                WhatIncludedId = WhatIncludedId,
                AccessibilityId = AccessibilityId,
                RestrictionId = RestrictionId

            };
            var result = await Mediator.Send(deleteTripActios);

            return result.Errors != null ? BadRequest(result) : Ok(result);
        }
    }
}
