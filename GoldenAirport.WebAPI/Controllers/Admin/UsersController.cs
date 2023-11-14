using GoldenAirport.Application.Users.Commands.CreateUser;
using GoldenAirport.Application.Users.Commands.Delete;
using GoldenAirport.Application.Users.Commands.EditUser;
using GoldenAirport.Application.Users.DTOs;
using GoldenAirport.Application.Users.Queries;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : BaseController<UsersController>
    {
        private readonly UserManager<AppUser> _userManager;
        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }



        [HttpGet("Fetch")]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var result = await Mediator.Send(query);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command)
        {
            //command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreateUserCommandValidator(_userManager).ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser(string Id, [FromForm] UpdateUserDto dto)
        {


            var command = new EditUserCommand
            {
                UserId = Id,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                UserType = dto.UserType,
                ProfilePicture = dto.ProfilePicture,
                CurrentUserId = CurrentUserId
                //UserName = dto.UserName,
                //NewPassword = dto.NewPassword,
                //CurrentPassword = dto.CurrentPassword,
                //ServiceFees = dto.ServiceFees,
                //TaxValue = dto.TaxValue,
                //BookingTime = dto.BookingTime,
                //PrivacyPolicyAndTerms = dto.PrivacyPolicyAndTerms,
                //Active = dto.Active,
            };
            var validationResults = await new EditUserCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var command = new DeleteUserCommand
            {
                UserId = Id,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }







    }
}
