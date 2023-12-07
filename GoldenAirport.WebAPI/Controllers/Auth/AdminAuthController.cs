using GoldenAirport.Application.Auth.Commands;
using GoldenAirport.Application.Users.Queries.Login;
using GoldenAirport.Domain.Entities.Auth;
using Hedaya.Application.Auth.Abstractions;
using Hedaya.Application.Auth.Models;
using Hedaya.Application.Auth.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace GoldenAirport.WebAPI.Controllers.Auth
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdminAuthController : BaseController<AdminAuthController>
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;

        public AdminAuthController(IAuthService authService, UserManager<AppUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var result = await Mediator.Send(query);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
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

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordDto userModel)
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

        [HttpPost("CheckOTP")]
        public async Task<IActionResult> CheckPasswordAsync([FromBody] LoginWithOTP loginWithOTP)
        {
            var result = await Mediator.Send(loginWithOTP);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}
