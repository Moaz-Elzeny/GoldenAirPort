using GoldenAirport.Application.Auth.Commands;
using GoldenAirport.Application.Users.Queries.Login;
using GoldenAirport.Domain.Entities.Auth;
using Hedaya.Application.Auth.Abstractions;
using Hedaya.Application.Auth.Models;
using Hedaya.Application.Auth.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace GoldenAirport.WebAPI.Controllers.Auth
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeeAuthController : BaseController<EmployeeAuthController>
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;

        public EmployeeAuthController(IAuthService authService, UserManager<AppUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }


        [HttpPost("EmployeeLogin")]
        public async Task<IActionResult> EmployeeLogin(EmployeeLoginQuery query)
        {
            var result = await Mediator.Send(query);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("LoginWithOTP")]
        public async Task<IActionResult> LoginWithOTP(int code, string username)
        {
            var query = new LoginWithOTP
            {
                Email = username,
                Code = code

            };
            var result = await Mediator.Send(query);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("changeEmployeepassword")]
        public async Task<IActionResult> changeEmployeepassword([FromBody] ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            var result = await _authService.ChangePasswordAsync(userId, model.CurrentPassword, model.NewPassword, ModelState);
            if (result is null)
            {
                return BadRequest(new { error = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? "عفوا لقد حدث خطأ" : "Something Went Wrong!" });
            }

            return Ok(result);
        }

        [HttpPost("forgotEmployeePassword")]
        public async Task<IActionResult> forgotEmployeePassword([FromBody] ForgotPasswordDto userModel)
        {

            var validationResult = await new ForgotPasswordValidator(_userManager).ValidateAsync(userModel);

            if (!validationResult.IsValid)
            {

                var errors = validationResult.Errors
                     .Select(error => new { error = error.ErrorMessage })
                     .ToList();

                return BadRequest(new { errors });
            }

            var result = await _authService.ForgetPasswordAsync(ModelState, userModel);

            return Ok(result);

        }
    }
}
