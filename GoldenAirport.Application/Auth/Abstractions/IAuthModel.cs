using Hedaya.Application.Auth.Models;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hedaya.Application.Auth.Abstractions
{
    public interface IAuthService
    {
        Task<dynamic> RegisterAsync(ModelStateDictionary modelState, RegisterModel model);
        //Task<dynamic> LoginAsync(ModelStateDictionary modelState, TokenRequestModel model, string WebRootPath);
        Task<dynamic> ForgetPasswordAsync(ModelStateDictionary modelState, ForgotPasswordDto userModel);
        Task<dynamic> RestPasswordAsync(ModelStateDictionary modelState, ResetPasswordModel userModel);
        Task<object> ChangePasswordAsync(string userId, string currentPassword, string newPassword, ModelStateDictionary modelState);
        Task<dynamic> GetUserAsync(ModelStateDictionary modelState, string userId, string WebRootPath);
        //Task<dynamic> UpdateUserAsync(UpdateProfileModel userModel, string userId);
        //Task<dynamic> UpdateProfilePicture(UpdateProfilePictureModel userModel, string userId, string WebRootPath);

        //Task<string> AddToRoleAsync(ModelStateDictionary modelState, AddRoleModel model);
        Task<dynamic> DeleteAccount(string Reason, string UserId);


        //object LogOut(ModelStateDictionary modelState, string authorization, string MobilID);

    }
}
