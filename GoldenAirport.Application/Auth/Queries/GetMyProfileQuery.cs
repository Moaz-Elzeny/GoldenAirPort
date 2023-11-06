using GoldenAirport.Application.Auth.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Users.Queries.GetMyProfile
{
    public record GetMyProfileQuery : IRequest<ResultDto<UserProfileDto>>
    {
        public string CurrentUserId { get; init; }
    }


    public class GetMyProfileQueryHandler : IRequestHandler<GetMyProfileQuery, ResultDto<UserProfileDto>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetMyProfileQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultDto<UserProfileDto>> Handle(GetMyProfileQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.FindByIdAsync(request.CurrentUserId);
            if (currentUser == null)
            {
                return ResultDto<UserProfileDto>.Failure(request.CurrentUserId, "User not found.");
            }

            var userProfile = new UserProfileDto
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                PhoneNumber = currentUser.PhoneNumber,
                //ServiceFees = currentUser.ServiceFees,
                UserType = currentUser.UserType,
                ProfilePicture = currentUser.ProfilePicture,
            };

            return ResultDto<UserProfileDto>.Success(userProfile, "User profile");
        }
    }
}
