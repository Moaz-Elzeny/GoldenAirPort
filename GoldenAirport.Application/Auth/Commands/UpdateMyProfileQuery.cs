using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Auth.Commands
{
    public class UpdateMyProfileQuery : IRequest<ResponseDto<object>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public string? CurrentUserId { get; init; }
    }

    public class UpdateMyProfileQueryHandler : IRequestHandler<UpdateMyProfileQuery, ResponseDto<object>>
    {
        private readonly UserManager<AppUser> _userManager;

        public UpdateMyProfileQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto<object>> Handle(UpdateMyProfileQuery request, CancellationToken cancellationToken)
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
            currentUser.FirstName = request.FirstName ?? currentUser.FirstName;
            currentUser.LastName = request.LastName ?? currentUser.LastName;
            currentUser.PhoneNumber = request.PhoneNumber ?? currentUser.PhoneNumber;   
            currentUser.Email = request.Email ?? currentUser.Email;
            currentUser.NormalizedEmail = request.Email.ToUpper() ?? currentUser.NormalizedEmail;

            await _userManager.UpdateAsync(currentUser);
            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "Updated successfull!",
                Result = new
                {
                    currentUser.Id
                }
            });

        }
    }
}
