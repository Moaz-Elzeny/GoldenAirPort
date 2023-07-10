using Etqaan.Application.Common.Models;
using Etqaan.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Etqaan.Application.Users.Queries.Login
{
    public record LoginQuery : IRequest<ResultDto<string>>
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }

    public class LoginQueryHandler : IRequestHandler<LoginQuery, ResultDto<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ResultDto<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return ResultDto<string>.Failure("Invalid login credentials.");
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                var jwtSecurityToken = await CreateJwtToken(user);
                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                return ResultDto<string>.Success(token);
            }
            else
            {
                return ResultDto<string>.Failure("Invalid login credentials.");
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
