using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenAirport.Application.Users.Queries.Login
{
    public record AuthService : IRequest<ResponseDto<object>>
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }

    public class LoginQueryHandler : IRequestHandler<AuthService, ResponseDto<object>>
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

        public async Task<ResponseDto<object>> Handle(AuthService request, CancellationToken cancellationToken)
           
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Message = "Invalid login credentials"
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
                        Token = token
                    }
                });
            }
            else
            {
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                     Message = "Invalid login credentials"
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
    }
}
