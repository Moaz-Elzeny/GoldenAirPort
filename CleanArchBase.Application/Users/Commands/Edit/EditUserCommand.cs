using CleanArchBase.Application.Common.Models;
using CleanArchBase.Domain.Entities.Auth;
using CleanArchBase.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace CleanArchBase.Application.Users.Commands.EditUser
{
    public record EditUserCommand : IRequest<ResultDto<string>>
    {
        public string UserId { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public string? AddressDetails { get; init; }
        public UserType? UserType { get; init; }
        public bool? Active { get; init; }
        public string? CurrentUserId { get; init; }

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

                user.AddressDetails = request.AddressDetails ?? user.AddressDetails;
                user.UserType = request.UserType ?? user.UserType;
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
                user.Active = request.Active ?? user.Active;

              
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
