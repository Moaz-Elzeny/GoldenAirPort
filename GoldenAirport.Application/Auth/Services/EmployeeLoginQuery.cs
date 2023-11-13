using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace GoldenAirport.Application.Users.Queries.Login
{
    public record EmployeeLoginQuery : IRequest<ResponseDto<object>>
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }

    public class EmployeeLoginQueryHandler : IRequestHandler<EmployeeLoginQuery, ResponseDto<object>>
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

        public async Task<ResponseDto<object>> Handle(EmployeeLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UserName);
            if (user == null)
            {
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Message = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? "الحساب خاطئ" : "Email Not Found" ,
                    Code = 101
                });

            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (result )
            {
                var jwtSecurityToken = await CreateJwtToken(user);
                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                var verificationCode = new Random().Next(1000, 9999).ToString();
                user.code = int.Parse(verificationCode);

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

                if (!user.TwoFactorEnabled)
                {
                    return ResponseDto<object>.Failure(new ErrorDto()
                    {
                        Message = "Invalid login credentials.",
                        Code = 101
                    });
                    //var otb = await _userManager.GenerateTwoFactorTokenAsync(user, "Default");
                    //var message =  _emailSender.SendEmailAsync("moazelzeny11@gmail.com", otb , "Done");
                    //await _emailSender.SendEmailAsync(user.Email, token, otb);
                }
                //CfDJ8JoHqfjrQnJJrqGsyM4dDzAozDixOr1qDScDsge64uuMEKsarQbnJMJdXGA9QD8x7+IbtoNmRVyep3vzfdh7USrtR7ai2joA2bt9zO5aGZWdNXi7QIjaNVaohVv4fqNPk2X4XtU3yJQDHvTDZYosRMDjQO1tsH6nBn3viD+2DbT0BtqCYydGRpKDC5dtsQNrMisWa96n9fohEl4IGYGxy2ayKfGGmgm2vkcNypz9kYIP
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Successfully",
                    Result = new
                    {

                        code = verificationCode
                    }
                }
                );

            }
            else
            {
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Message = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? "تسجيل الدخول غير صالح" : "Invalid login credentials",
                    Code = 101
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
    }
}
