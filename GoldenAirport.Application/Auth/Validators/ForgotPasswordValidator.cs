using FluentValidation;
using GoldenAirport.Domain.Entities.Auth;
using Hedaya.Application.Auth.Models;
using Microsoft.AspNetCore.Identity;

namespace Hedaya.Application.Auth.Validators
{


    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
    {
        private readonly UserManager<AppUser> _userManager;

        public ForgotPasswordValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("Please enter a valid Email");
        }
    }

}
