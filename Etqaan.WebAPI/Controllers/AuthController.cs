using Etqaan.Application.Users.Queries.GetMyProfile;
using Etqaan.Application.Users.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace Etqaan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : BaseController<AuthController>
    {

        [HttpGet("profile")]
        public async Task<IActionResult> GetMyProfile()
        {
            var query = new GetMyProfileQuery
            {
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }



    }
}
