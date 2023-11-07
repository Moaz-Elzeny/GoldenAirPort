using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Entities.Auth;
using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Users.Commands.EditUser
{
    public record EditUserCommand : IRequest<ResponseDto<object>>
    {
        public string UserId { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? CurrentPassword { get; init; }
        public string? NewPassword { get; init; }
        public string? ConfirmNewPassword { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public UserType? UserType { get; init; }
        public IFormFile? ProfilePicture { get; set; }
        public string? CurrentUserId { get; init; }
        //public decimal? ServiceFees { get; init; }
        //public int? TaxValue { get; set; }
        //public int? BookingTime { get; set; }
        //public string? PrivacyPolicyAndTerms { get; set; }

        public class EditUserCommandHandler : IRequestHandler<EditUserCommand, ResponseDto<object>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IHostingEnvironment _environment;

            public EditUserCommandHandler(UserManager<AppUser> userManager, IHostingEnvironment environment)
            {
                _userManager = userManager;
                _environment = environment;
            }

            public async Task<ResponseDto<object>> Handle(EditUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                if (user == null)
                    return ResponseDto<object>.Failure(new ErrorDto() { Message = $"User not found {request.UserId}", Code = 101 });


                if (request.UserName != null)
                    user.UserName = request.UserName;

                if (request.Email != null)
                    user.Email = request.Email;

                if (request.FirstName != null)
                    user.FirstName = request.FirstName;

                if (request.LastName != null)
                    user.LastName = request.LastName;

                // if (request.BookingTime != null)
                //    user.BookingTime = (byte)request.BookingTime;

                //  if (request.TaxValue != null)
                //    user.TaxValue = (byte)request.TaxValue;

                //user.ServiceFees = request.ServiceFees ?? user.ServiceFees;
                //user.PrivacyPolicyAndTerms = request.PrivacyPolicyAndTerms ?? user.PrivacyPolicyAndTerms;
                user.UserType = request.UserType ?? user.UserType;
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
                user.ModificationDate = DateTime.Now;
                user.ModifiedById = request.CurrentUserId;

                if (request.ProfilePicture != null)
                {
                    if (!string.IsNullOrEmpty(user.ProfilePicture))
                    {
                        FileHelper.DeleteFile(user.ProfilePicture, _environment);
                    }
                    user.ProfilePicture = await FileHelper.SaveImageAsync(request.ProfilePicture, _environment);
                }

                if (request.CurrentPassword != null)
                {
                    var x = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

                    if (!x.Succeeded)
                    {
                        return ResponseDto<object>.Failure(new ErrorDto() { Message = $"Password is Wrong .. Please return password {request.CurrentUserId}", Code = 101 });
                    }
                }
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Updated successfull!",
                        Result = new
                        {
                            request.UserId
                        }
                    }
);
                }
                else
                {
                    return ResponseDto<object>.Failure(new ErrorDto() { Message = $"Failed to update user {request.UserId}", Code = 101 });
                }
            }
        }
    }
}
