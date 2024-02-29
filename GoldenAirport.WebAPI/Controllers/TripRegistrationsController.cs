using GoldenAirport.Application.TripRegistrations.Commands.Create;
using GoldenAirport.Application.TripRegistrations.Commands.Delete;
using GoldenAirport.Application.TripRegistrations.Commands.Edit;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Application.TripRegistrations.Queries;
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
            (string? userId, int pageNumber =1)
        {
            var query = new GetTripRegistrationQuery
            {
                UserId = userId,
                PageNumber = pageNumber,
                CurrentUserId = CurrentUserId,
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
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create( CreateTripRegistrationCommand command)
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
        

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int Id, UpdateTripRegistrationDto dto)
        {
            var command = new EditTripRegistrationCommand
            {
                Id = Id,               
                TripId = dto.TripId,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Adults = dto.Adult,
                Children = dto.Child,
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
            var deleteTripRegistration = new DeleteTripRegistrationCommand { Id = Id , CurrentUserId = CurrentUserId };
            var result = await Mediator.Send(deleteTripRegistration);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}

