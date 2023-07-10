using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Domain.Entities.Auth;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Etqaan.Application.Users.Commands.EditUser
{
    public class EditUserCommand : IRequest<ResultDto<string>>
    {
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? NationalIdNumber { get; set; }
        public Religion? Religion { get; set; }
        public string? AddressDetails { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public UserType? UserType { get; set; }
        public int? NationalityId { get; set; }
        public bool? Active { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditUserCommandHandler : IRequestHandler<EditUserCommand, ResultDto<string>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IHostingEnvironment _environment;

            public EditUserCommandHandler(UserManager<AppUser> userManager, IHostingEnvironment environment)
            {
                _userManager = userManager;
                _environment = environment;
            }

            public async Task<ResultDto<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                if (user == null)
                    return ResultDto<string>.Failure("User not found");

                if (request.UserName != null)
                    user.UserName = request.UserName;

                if (request.Email != null)
                    user.Email = request.Email;

                if (request.FirstName != null)
                    user.FirstName = request.FirstName;

                if (request.LastName != null)
                    user.LastName = request.LastName;

                user.DateOfBirth = request.DateOfBirth ?? user.DateOfBirth;
                user.Gender = request.Gender ?? user.Gender;
                user.NationalIdNumber = request.NationalIdNumber ?? user.NationalIdNumber;
                user.Religion = request.Religion ?? user.Religion;
                user.AddressDetails = request.AddressDetails ?? user.AddressDetails;
                user.UserType = request.UserType ?? user.UserType;
                user.NationalityId = request.NationalityId ?? user.NationalityId;
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
                user.Active = request.Active ?? user.Active;

                // Delete old profile picture if a new one is provided
                if (request.ProfilePicture != null)
                {
                    if (!string.IsNullOrEmpty(user.ProfilePicture))
                    {
                        FileHelper.DeleteFile(user.ProfilePicture, _environment);
                    }

                    user.ProfilePicture = await FileHelper.SaveImageAsync(request.ProfilePicture, _environment);
                }

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return ResultDto<string>.Success("User updated successfully");
                }
                else
                {
                    return ResultDto<string>.Failure("Failed to update user");
                }
            }
        }
    }
}
