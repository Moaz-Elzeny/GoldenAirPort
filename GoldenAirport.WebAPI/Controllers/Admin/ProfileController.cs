using GoldenAirport.Application.Users.Queries.GetMyProfile;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfileController : BaseController<ProfileController>
    {
        public ProfileController() { }

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
    }
}
