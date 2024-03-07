using GoldenAirport.Application.Auth.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Users.Queries.GetMyProfile
{
    public record GetMyProfileQuery : IRequest<ResponseDto<object>>
    {
        public string CurrentUserId { get; init; }
    }


    public class GetMyProfileQueryHandler : IRequestHandler<GetMyProfileQuery, ResponseDto<object>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetMyProfileQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto<object>> Handle(GetMyProfileQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.FindByIdAsync(request.CurrentUserId);
            if (currentUser == null)
            {
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Message = "Invalid login credentials.",
                    Code = 101
                });
            }

            var userProfile = new UserProfileDto
            {
                Id = currentUser.Id,
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                PhoneNumber = currentUser.PhoneNumber,
                //ServiceFees = currentUser.ServiceFees,
                UserType = currentUser.UserType,
                ProfilePicture = currentUser.ProfilePicture,
                CountryId = currentUser.CountryId
            };

            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "User profile",
                Result = new
                {
                   userProfile
                }
            });
        }
    }
}
