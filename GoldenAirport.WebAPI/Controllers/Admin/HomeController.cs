using GoldenAirport.Application.AdminDetails.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HomeController : BaseController<HomeController>
    {
        public HomeController() { }

        public async Task<IActionResult> GetAdminDetails()
        {

            var query = new AdminHomeQuery { UserId = CurrentUserId };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
