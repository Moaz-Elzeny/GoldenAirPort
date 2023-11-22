using GoldenAirport.Application.Notifications.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NotificationsController : BaseController<NotificationsController>
    {
        public NotificationsController() { }

        [HttpGet("AdminNotifications")]
        public async Task<IActionResult> AdminNotifications()
        {
            var query = new AdminNotificationsQuery();
            //{
            //    PageNumber = pageNumber,
            //};
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpGet("EmployeeNotifications")]
        public async Task<IActionResult> EmployeeNotifications()
        {
            var query = new EmployeeNotificationsQuery();
  
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
