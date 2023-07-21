using CleanArchBase.Application.Auth.DTOs;
using CleanArchBase.Application.Common.Models;
using CleanArchBase.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace CleanArchBase.Application.Users.Queries.GetMyProfile
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
                return ResultDto<UserProfileDto>.Failure("User not found.");
            }

            var userProfile = new UserProfileDto
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                PhoneNumber = currentUser.PhoneNumber,
                DateOfBirth = currentUser.DateOfBirth,
                AddressDetails = currentUser.AddressDetails,
                UserType = currentUser.UserType,
            };

            return ResultDto<UserProfileDto>.Success(userProfile);
        }
    }
}
