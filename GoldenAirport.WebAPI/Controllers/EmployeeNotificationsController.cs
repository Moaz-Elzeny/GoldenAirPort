using GoldenAirport.Application.Notifications.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeeNotificationsController : BaseController<EmployeeNotificationsController>
    {
        public EmployeeNotificationsController() { }

        [HttpGet("fetch")]
        public async Task<IActionResult> EmployeeNotifications(bool? Seen)
        {
            var query = new EmployeeNotificationsQuery { Seen = Seen, CurrentUserId = CurrentUserId};

            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
