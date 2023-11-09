using GoldenAirport.Domain.Entities.Auth;
using Hedaya.Application.Auth.Abstractions;
using Hedaya.Application.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace GoldenAirport.Application.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationDbContext _context;

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthService(IApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<object> ChangePasswordAsync(string userId, string currentPassword, string newPassword, ModelStateDictionary modelState)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new { error = e.Description }).ToList();
                return new { errors };
            }

            await _signInManager.RefreshSignInAsync(user);

            return new { Message = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? "تم تغيير كلمة السر بنجاح" : "Password Changed Successfully" };
        }

        public async Task<dynamic> ForgetPasswordAsync(ModelStateDictionary modelState, ForgotPasswordDto userModel)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(userModel.Email);

                // Generate a random 6-digit verification code
                var verificationCode = new Random().Next(1000, 9999).ToString();
                user.code = int.Parse(verificationCode);
                // Send the verification code to the user's phone number via SMS

                //TwilioClient.Init(accountSid, authToken);
                //var message = MessageResource.Create(
                //    body: $"Hi {user.UserName}, To Reset Your Password Please Use This Code: {verificationCode}",
                //    from: new PhoneNumber("your_twilio_phone_number_here"),
                //    to: new PhoneNumber(user.PhoneNumber)
                //);

                // Update the user's SecurityCode with the verification code
                //user.SecurityCode = verificationCode;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => new { error = e.Description }).ToList();
                    return new { errors };
                }

                return new
                {
                    Result = new
                    {
                        code = verificationCode
                    }
                };

            }
            catch (Exception ex)
            {
                modelState.AddModelError(string.Join(",", ex.Data), string.Join(",", ex.InnerException));
                return new { Message = $"{ex.Message}" };
            }
        }

        public Task<dynamic> RegisterAsync(ModelStateDictionary modelState, RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
