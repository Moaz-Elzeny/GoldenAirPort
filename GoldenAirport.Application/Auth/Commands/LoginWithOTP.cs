using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Users.Queries.Login;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using GoldenAirport.Application.Auth.Commands;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using NuGet.Common;
using GoldenAirport.Application.AdminDetails.DTOs;

namespace GoldenAirport.Application.Auth.Commands
{
    public class LoginWithOTP : IRequest<ResponseDto<object>>
    {
        public string UserName { get; init; }
        public string Code { get; init; }
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
        var user = await _userManager.FindByNameAsync(request.UserName);
        var signIn = await _signInManager.TwoFactorSignInAsync("Email", request.Code, false, false);
        if (signIn.Succeeded)
        {
            if (user != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, request.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                //var jwtToken = GetToken(authClaims);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Successfully",
                    Result = new
                    {
                        Token = signIn.ToString()
                    }
                }
);
            };
            //returning the token...
        }
        return ResponseDto<object>.Success(new ResultDto()
        {
            Message = "Successfully",
            Result = new
            {
                Token = signIn.ToString()
            }
        }
       );
   
}
    //return StatusCode(StatusCodes.Status404NotFound,
    //    new Response { Status = "Success", Message = $"Invalid Code" });
}


