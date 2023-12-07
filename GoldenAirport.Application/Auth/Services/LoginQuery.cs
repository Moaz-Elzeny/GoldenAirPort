using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenAirport.Application.Users.Queries.Login
{
    public record LoginQuery : IRequest<ResponseDto<object>>
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }

    public class LoginQueryHandler : IRequestHandler<LoginQuery, ResponseDto<object>>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<ResponseDto<object>> Handle(LoginQuery request, CancellationToken cancellationToken)
           
        {
            var user = await _userManager.FindByEmailAsync(request.UserName);
            if (user == null || user.UserType != Domain.Enums.UserType.SuperAdmin)
            {
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Code = 101,
                    Message = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? "الحساب خاطئ" : "Email Not Found" 
                });
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                var jwtSecurityToken = await CreateJwtToken(user);
                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                    var e = await _context.AppUsers.Where(e => e.Id == user.Id).FirstOrDefaultAsync();
                    if (e != null)
                    {
                        e.LastLogin = DateTime.Now;
                    }
                    await _context.SaveChangesAsync(cancellationToken);
               
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Successfully",
                    Result = new
                    {
                        Token = token,
                        UserType = user.UserType
                    }
                });
            }
            else
            {
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Code = 103,
                     Message = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? "تسجيل الدخول غير صالح" : "Invalid login credentials" 
                });
            }
        }

        private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lG0rDWELYD0jPtoLNlc/sMVREJMh8laXd5bvVEZzUeg="));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "SecureApi",
                audience: "SecureApiUser",
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;


        }

        //public async Task<object> ChangePasswordAsync(string userId, string currentPassword, string newPassword, ModelStateDictionary modelState)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        //    if (!result.Succeeded)
        //    {
        //        var errors = result.Errors.Select(e => new { error = e.Description }).ToList();
        //        return new { errors };
        //    }

        //    await _signInManager.RefreshSignInAsync(user);

        //    return new { Message = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? "تم تغيير كلمة السر بنجاح" : "Password Changed Successfully" };
        //}


        //public async Task<dynamic> ForgetPasswordAsync(ModelStateDictionary modelState, ForgotPasswordDto userModel)
        //{
        //    try
        //    {

        //        var user = await _userManager.FindByNameAsync(userModel.Email);

        //        // Generate a random 6-digit verification code
        //        var verificationCode = new Random().Next(1000, 9999).ToString();

        //        // Send the verification code to the user's phone number via SMS

        //        //TwilioClient.Init(accountSid, authToken);
        //        //var message = MessageResource.Create(
        //        //    body: $"Hi {user.UserName}, To Reset Your Password Please Use This Code: {verificationCode}",
        //        //    from: new PhoneNumber("your_twilio_phone_number_here"),
        //        //    to: new PhoneNumber(user.PhoneNumber)
        //        //);

        //        // Update the user's SecurityCode with the verification code
        //        //user.SecurityCode = verificationCode;
        //        var result = await _userManager.UpdateAsync(user);
        //        if (!result.Succeeded)
        //        {
        //            var errors = result.Errors.Select(e => new { error = e.Description }).ToList();
        //            return new { errors };
        //        }

        //        return new
        //        {
        //            Result = new
        //            {
        //                code = verificationCode
        //            }
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        modelState.AddModelError(string.Join(",", ex.Data), string.Join(",", ex.InnerException));
        //        return new { Message = $"{ex.Message}" };
        //    }
        //}

    }
}
