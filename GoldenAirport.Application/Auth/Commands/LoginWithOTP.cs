using GoldenAirport.Application.Auth.Commands;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenAirport.Application.Auth.Commands
{
    public class LoginWithOTP : IRequest<ResponseDto<object>>
    {
        public string Email { get; init; }
        public int Code { get; init; }
    }
}

public class EmployeeLoginQueryHandler : IRequestHandler<LoginWithOTP, ResponseDto<object>>
{
    private readonly IApplicationDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IEmailSender _emailSender;

    public EmployeeLoginQueryHandler(IApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSender emailSender)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
    }

    public async Task<ResponseDto<object>> Handle(LoginWithOTP request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);


        if (user.code == request.Code)
        {
            var jwtSecurityToken = await CreateJwtToken(user);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "Successfully",
                Result = new
                {
                    Token = token.ToString(),
                    UserType = user.UserType
                }
            });
        }

        //var signIn = await _signInManager.TwoFactorSignInAsync("Email", request.Code, false, false);
        //if (signIn.Succeeded)
        //{
        //    if (user != null)
        //    {
        //        var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, request.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        foreach (var role in userRoles)
        //        {
        //            authClaims.Add(new Claim(ClaimTypes.Role, role));
        //        }

        //        //var jwtToken = GetToken(authClaims);

        //        return ResponseDto<object>.Success(new ResultDto()
        //        {
        //            Message = "Successfully",
        //            Result = new
        //            {
        //                Token = signIn.ToString()
        //            }
        //        });
        //    };
        //returning the token...
        //}
        return ResponseDto<object>.Failure(new ErrorDto()
        {
            Message = "Code is wrong",
            Code = 101
        });
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
    //return StatusCode(StatusCodes.Status404NotFound,
    //    new Response { Status = "Success", Message = $"Invalid Code" });
}


