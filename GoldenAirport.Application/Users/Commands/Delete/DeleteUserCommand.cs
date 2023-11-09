using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ResponseDto<object>>
    {
        public string UserId { get; set; }
        public string CurrentUserId { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseDto<object>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IHostingEnvironment _environment;

            public DeleteUserCommandHandler(UserManager<AppUser> userManager, IHostingEnvironment environment)
            {
                _userManager = userManager;
                _environment = environment;
            }

            public async Task<ResponseDto<object>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                if (user == null)
                {
                    return  ResponseDto<object>.Failure(new ErrorDto() { Message = "user not found", Code = 101 });
                }

                if (user.Id == request.CurrentUserId)
                {
                    return ResponseDto<object>.Failure(new ErrorDto() { Message = $"Cannot delete your own user {request.CurrentUserId}", Code = 101 });                   
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
                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Deleted Successfully!",
                        Result = new
                        {
                            result = user.Id
                        }
                    });
                }
                else
                {
                    return ResponseDto<object>.Failure(new ErrorDto() { Message = $"Failed to delete user {request.UserId}", Code = 101 });
                }
            }
        }
    }

}
