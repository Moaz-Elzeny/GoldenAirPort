using Etqaan.Domain.Entities.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Etqaan.Application.Users.Commands.CreateUser
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

            RuleFor(x => x.NationalIdNumber)
                .NotEmpty().WithMessage("National ID number is required.")
                .MaximumLength(20).WithMessage("National ID number cannot exceed 20 characters.")
                                        .MustAsync(BeUniqueNationalIdNumber).WithMessage("Nationality ID is already taken.");
            ;

            RuleFor(x => x.AddressDetails)
                .MaximumLength(500).WithMessage("Address details cannot exceed 250 characters.");

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Invalid gender value.");

            RuleFor(x => x.Religion)
                .IsInEnum().WithMessage("Invalid religion value.");

            RuleFor(x => x.UserType)
                .IsInEnum().WithMessage("Invalid user type value.");
            RuleFor(x => x.NationalityId)
                        .NotEmpty().WithMessage("Nationality ID is required.")
                        .GreaterThan(0).WithMessage("Nationality ID must be greater than 0.");
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
        private async Task<bool> BeUniqueNationalIdNumber(string NationalIdNumber, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NationalIdNumber == NationalIdNumber);
            return existingUser == null;
        }
    }
}
