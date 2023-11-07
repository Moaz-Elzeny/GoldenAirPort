using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Users.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<ResponseDto<object>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ResponseDto<object>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUsersQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto<object>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();

            var userDtos = users.Select(user => new UserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //ServiceFees = user.ServiceFees,
                //TaxValue = user.TaxValue,
                //BookingTime = user.BookingTime,
                UserType = user.UserType,
                ProfilePicture = user.ProfilePicture,
                //PrivacyPolicyAndTerms = user.PrivacyPolicyAndTerms,

            }).ToList();

            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "All users",
                Result = new
                {
                    result = userDtos
                }
            });
        }
    }

}
