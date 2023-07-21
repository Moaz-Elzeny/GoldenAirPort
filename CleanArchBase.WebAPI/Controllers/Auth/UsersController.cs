using CleanArchBase.Application.Users.Commands.CreateUser;
using CleanArchBase.Application.Users.Commands.Delete;
using CleanArchBase.Application.Users.Commands.EditUser;
using CleanArchBase.Application.Users.DTOs;
using CleanArchBase.Application.Users.Queries;
using CleanArchBase.Domain.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchBase.WebAPI.Controllers
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



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreateUserCommandValidator(_userManager).ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string Id, [FromForm] UpdateUserDto dto)
        {


            var command = new EditUserCommand
            {
                UserId = Id,
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                AddressDetails = dto.AddressDetails,
                UserType = dto.UserType,
                Active = dto.Active,
                CurrentUserId = CurrentUserId
            };
            var validationResults = await new EditUserCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var command = new DeleteUserCommand
            {
                UserId = Id,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }







    }
}
