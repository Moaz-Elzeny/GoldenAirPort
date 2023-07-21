using CleanArchBase.Domain.Entities.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace CleanArchBase.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.UserName)
                 .NotEmpty().WithMessage("Username is required.")
                 .MustAsync(BeUniqueUserName).WithMessage("Username is already taken.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(BeUniqueEmail).WithMessage("Email is already taken.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

           
            RuleFor(x => x.AddressDetails)
                .MaximumLength(500).WithMessage("Address details cannot exceed 250 characters.");

           
           
            RuleFor(x => x.UserType)
                .IsInEnum().WithMessage("Invalid user type value.");
           
        }
        private async Task<bool> BeUniqueUserName(string userName, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByNameAsync(userName);
            return existingUser == null;
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            return existingUser == null;
        }
       
    }
}
