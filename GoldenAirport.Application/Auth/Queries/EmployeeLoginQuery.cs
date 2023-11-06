using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace GoldenAirport.Application.Users.Queries.Login
{
    public record EmployeeLoginQuery : IRequest<ResultDto<string>>
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }

    public class EmployeeLoginQueryHandler : IRequestHandler<EmployeeLoginQuery, ResultDto<string>>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public EmployeeLoginQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IApplicationDbContext context, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailSender = emailSender;
        }

        public async Task<ResultDto<string>> Handle(EmployeeLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return ResultDto<string>.Failure(user.Id, "Invalid login credentials.");
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (result )
            {
                var jwtSecurityToken = await CreateJwtToken(user);
                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                if (user.UserType == Domain.Enums.UserType.Employee)
                {
                    user.TwoFactorEnabled = true;
                    var e = await _context.Employees.Where(e => e.AppUserId == user.Id).FirstOrDefaultAsync();
                    if (e != null)
                    {
                        e.LastLogin = DateTime.Now;
                    }
                    await _userManager.UpdateAsync(user);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                if (user.TwoFactorEnabled)
                {
                    var otb = await _userManager.GenerateTwoFactorTokenAsync(user, "Default");
                    var message =  _emailSender.SendEmailAsync("moazelzeny11@gmail.com", otb , "Done");
                    await _emailSender.SendEmailAsync(user.Email, token, otb);
                }

                return ResultDto<string>.Success(token, "Token");
            }
            else
            {
                return ResultDto<string>.Failure(user.Id, "Invalid login credentials.");
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
    }
}
