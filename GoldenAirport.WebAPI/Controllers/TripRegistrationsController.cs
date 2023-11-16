using GoldenAirport.Application.TripRegistrations.Commands.Create;
using GoldenAirport.Application.TripRegistrations.Commands.Delete;
using GoldenAirport.Application.TripRegistrations.Commands.Edit;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Application.TripRegistrations.Queries;
using GoldenAirport.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TripRegistrationsController : BaseController<TripRegistrationsController>
    {
        public TripRegistrationsController()
        {
        }


        [HttpGet("fetch")]
        public async Task<IActionResult> GetAllTrips
            ( int pageNumber )
        {
            var query = new GetTripRegistrationQuery
            {
                PageNumber = pageNumber,
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
        
        [HttpGet("fetch1")]
        public async Task<IActionResult> GetTripById
            (int id )
        {
            var query = new GetTripRegistrationByIdQuery
            {
                Id = id
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
        
        [HttpGet("GetAdult")]
        public async Task<IActionResult> GetAdult
            (int TripRegistrationId)
        {
            var query = new GetAdultQuery
            {
                TripRegistrationId = TripRegistrationId
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateTripRegistrationCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreateTripRegistrationCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);

        }
        
        [HttpPost("CreateAdult")]
        public async Task<IActionResult> CreateAdult( CreateAdultCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            
            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromHeader] int Id, [FromForm] UpdateTripRegistrationDto dto)
        {
            var command = new EditTripRegistrationCommand
            {
                Id = Id,
                PackageCost = dto.PackageCost,
                TaxesAndFees = dto.TaxesAndFees,
                OtherFees = dto.OtherFees,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Title = dto.Title,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                AdultPassportNo = dto.AdultPassportNo,
                DateOfBirth = dto.DateOfBirth,
                ChildPassportNo = dto.ChildPassportNo,
                AgeRange = dto.AgeRange,
                TripId = dto.TripId,
                NoOfAdults = dto.NoOfAdults,
                CurrentUserId = CurrentUserId
            };

            var validationResults = await new EditTripRegistrationCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleteTripRegistration = new DeleteTripRegistrationCommand { Id = Id };
            var result = await Mediator.Send(deleteTripRegistration);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}

