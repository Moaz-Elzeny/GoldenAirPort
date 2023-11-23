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
        public async Task<IActionResult> EmployeeNotifications()
        {
            var query = new EmployeeNotificationsQuery { CurrentUserId = CurrentUserId};

            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
