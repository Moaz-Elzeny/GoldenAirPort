using GoldenAirport.Application.Notifications.Queries;
using GoldenAirport.Application.PackageRegistrations.Commands.Edit;
using GoldenAirport.Application.RegistrationsEditing.Queries;
using GoldenAirport.Application.TripRegistrations.Commands.Edit;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdminNotificationsController : BaseController<AdminNotificationsController>
    {
        public AdminNotificationsController() { }

        [HttpGet("fetch")]
        public async Task<IActionResult> AdminNotifications()
        {
            var query = new AdminNotificationsQuery();

            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpGet("fetchByTripRegistrationId")]
        public async Task<IActionResult> TripRegistrationEditingByIdQuery(int id)
        {
            var query = new TripRegistrationEditingByIdQuery
            {
                Id = id
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpGet("fetchByPackageRegistrationId")]
        public async Task<IActionResult> PackageRegistrationEditingById(int id)
        {
            var query = new PackageRegistrationEditingByIdQuery
            {
                Id = id
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpPut("ApproveTripRegistrationEditing")]
        public async Task<IActionResult> ApproveTripRegistrationEditing(int Id, bool Approve = true)
        {
            var command = new ApproveTripRegistrationEditingCommand
            {
                TripRegistrationId = Id,
                Approve = Approve,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPut("ApprovePackageRegistrationEditing")]
        public async Task<IActionResult> ApprovePackageRegistrationEditing(int Id, bool Approve = true)
        {
            var command = new ApprovePackageRegistrationEditingCommand
            {
                PackageRegistrationId = Id,
                Approve = Approve,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
