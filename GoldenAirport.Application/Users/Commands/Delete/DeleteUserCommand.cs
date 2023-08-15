using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ResultDto<Unit>>
    {
        public string UserId { get; set; }
        public string CurrentUserId { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultDto<Unit>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IHostingEnvironment _environment;

            public DeleteUserCommandHandler(UserManager<AppUser> userManager, IHostingEnvironment environment)
            {
                _userManager = userManager;
                _environment = environment;
            }

            public async Task<ResultDto<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                if (user == null)
                {
                    return ResultDto<Unit>.Failure("User not found");
                }

                if (user.Id == request.CurrentUserId)
                {
                    return ResultDto<Unit>.Failure("Cannot delete your own user");
                }

                user.Deleted = true;
                user.ModifiedById = request.CurrentUserId;
                user.ModificationDate = DateTime.Now;

                if (!string.IsNullOrEmpty(user.ProfilePicture))
                {
                    FileHelper.DeleteFile(user.ProfilePicture, _environment);
                }

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return ResultDto<Unit>.Success(Unit.Value);
                }
                else
                {
                    return ResultDto<Unit>.Failure("Failed to delete user");
                }
            }
        }
    }

}
