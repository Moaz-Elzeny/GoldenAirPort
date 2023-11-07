using GoldenAirport.Application.Auth.Commands;
using GoldenAirport.Application.Users.Queries.GetMyProfile;
using GoldenAirport.Application.Users.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Auth
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


            return result.Error != null ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var result = await Mediator.Send(query);

            return !result.IsSuccess? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpPost("EmployeeLogin")]
        public async Task<IActionResult> EmployeeLogin(EmployeeLoginQuery query)
        {
            var result = await Mediator.Send(query);

            return result.Error != null ? BadRequest(result) : Ok(result);
        }

        [HttpPost("LoginWithOTP")]
        public async Task<IActionResult> LoginWithOTP(string code, string username)
        {
            var query = new LoginWithOTP
            {
                UserName = username,
                Code = code

            };
            var result = await Mediator.Send(query);

            return result.Error != null ? BadRequest(result) : Ok(result);
        }
        }
}
