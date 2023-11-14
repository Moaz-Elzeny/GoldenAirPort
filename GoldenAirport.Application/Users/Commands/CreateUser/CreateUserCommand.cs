using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Users.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenAirport.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ResponseDto<object>>
    {
        //public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }        
        public UserType UserType { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string? CurrentUserId { get; set; }
        //public decimal ServiceFees { get; set; }
        //public int? TaxValue { get; set; }
        //public int BookingTime { get; set; }
        //public string? PrivacyPolicyAndTerms { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseDto<object>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IHostingEnvironment _environment;

            public CreateUserCommandHandler(UserManager<AppUser> userManager, IHostingEnvironment environment)
            {
                _userManager = userManager;
                _environment = environment;
            }

            public async Task<ResponseDto<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new AppUser
                {
                    UserName = request.Email,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserType = request.UserType,
                    CreatedById ="emp",
                    CreationDate = DateTime.Now,
                    PhoneNumber = request.PhoneNumber,
                    //ServiceFees = request.ServiceFees,
                    //TaxValue = (byte)request.TaxValue,
                    //BookingTime = (byte)request.BookingTime,
                    //PrivacyPolicyAndTerms = request.PrivacyPolicyAndTerms,
                };

                if (request.ProfilePicture != null)
                {
                    user.ProfilePicture = await FileHelper.SaveImageAsync(request.ProfilePicture, _environment);
                }

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, request.UserType.ToString());

                    var jwtSecurityToken = await CreateJwtToken(user);
                    var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                    var userId = user.Id;
                    var Token = new UserTokenDto { UserId = userId, Token = token };

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Token!",
                        Result = new
                        {
                            Token
                        }
                    }
);
                }
                else
                {
                    return ResponseDto<object>.Failure(new ErrorDto() { Message = $"Failed to create user {user.Id}", Code = 101 });

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

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("agQxFnKSqDaysE7FxWdj417E4MBd5ZQAqh0ACsSDJFA="));
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
}
