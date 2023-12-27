using GoldenAirport.Application.Infrastructure;
using GoldenAirport.Application.TripRegistrations.Queries;
using GoldenAirport.Application.Trips.Commands.Create;
using GoldenAirport.Application.Trips.Commands.Delete;
using GoldenAirport.Application.Trips.Commands.Edit;
using GoldenAirport.Application.Trips.Dtos;
using GoldenAirport.Application.Trips.Queries;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Permissions.Trips.Actions)]
        [HttpGet("fetch")]
        public async Task<IActionResult> GetAllTrips
            ([FromQuery] int pageNumber,
            int? FromCity,
            [FromQuery] List<int>? ToCity,
            [FromQuery] DateTime? StartingOn,
            int? Guests)
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
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        //[Authorize(Permissions.Trips.Actions)]
        [HttpGet("fetch1")]
        public async Task<IActionResult> GetTripById
            (int id)
        {
            var query = new GetTripByIdQuery
            {
                Id = id
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        //[Authorize(Permissions.Trips.Actions)]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateTripCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreateTripCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);

        }

        //[Authorize(Permissions.Trips.Actions)]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int Id, [FromForm] UpdateTripDto dto)
        {
            var command = new EditTripCommand
            {
                Id = Id,
                StartingDate = dto.StartingDate,
                EndingDate = dto.EndingDate,
                Price = dto.AdultPrice,
                ChildPrice = dto.ChildPrice,
                Guests = dto.Guests,
                TripHours = dto.TripHours,
                FromCityId = dto.FromCityId,
                ToCitiesIds = dto.ToCitiesIds,
                //PaymentOptions = dto.PaymentOptions,
                IsRefundable = dto.IsRefundable,
                CurrentUserId = CurrentUserId
            };

            var validationResults = await new EditTripCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        //[Authorize(Permissions.Trips.Actions)]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleteTrip = new DeleteTripCommand { Id = Id };
            var result = await Mediator.Send(deleteTrip);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpDelete("DeleteActions")]
        public async Task<IActionResult> DeleteActions(int TripId, int? WhyVisitId, int? WhatIncludedId, int? AccessibilityId, int? RestrictionId)
        {
            var deleteTripActions = new DeleteActionsInTripCommand
            {
                TripId = TripId,
                WhyVisitId = WhyVisitId,
                WhatIncludedId = WhatIncludedId,
                AccessibilityId = AccessibilityId,
                RestrictionId = RestrictionId

            };
            var result = await Mediator.Send(deleteTripActions);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
