using GoldenAirport.Application.Auth.Commands;
using GoldenAirport.Application.Auth.DTOs;
using GoldenAirport.Application.Users.Commands.EditUser;
using GoldenAirport.Application.Users.DTOs;
using GoldenAirport.Application.Users.Queries.GetMyProfile;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfileController : BaseController<ProfileController>
    {
        public ProfileController() { }

        [HttpGet("fetch")]
        public async Task<IActionResult> GetMyProfile()
        {
            var query = new GetMyProfileQuery
            {
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(query);


            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserProfileDto dto)
        {


            var command = new UpdateMyProfileQuery
            {
                CurrentUserId = CurrentUserId,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
              
            };
            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
