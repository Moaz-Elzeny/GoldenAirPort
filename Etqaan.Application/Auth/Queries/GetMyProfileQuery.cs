using Etqaan.Application.Auth.DTOs;
using Etqaan.Application.Common.Models;
using Etqaan.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace Etqaan.Application.Users.Queries.GetMyProfile
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
                Gender = currentUser.Gender,
                NationalIdNumber = currentUser.NationalIdNumber,
                Religion = currentUser.Religion,
                AddressDetails = currentUser.AddressDetails,
                ProfilePictureUrl = currentUser.ProfilePicture,
                UserType = currentUser.UserType,
                NationalityId = currentUser.NationalityId
            };

            return ResultDto<UserProfileDto>.Success(userProfile);
        }
    }
}
