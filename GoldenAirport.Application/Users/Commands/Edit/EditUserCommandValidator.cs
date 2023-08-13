using FluentValidation;

namespace GoldenAirport.Application.Users.Commands.EditUser
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {

        public EditUserCommandValidator()
        {

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.FirstName)
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

            RuleFor(x => x.LastName)
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");


           
            RuleFor(x => x.AddressDetails)
                .MaximumLength(250).WithMessage("Address details cannot exceed 250 characters.");



            RuleFor(x => x.UserType)
                .IsInEnum().WithMessage("Invalid user type value.");

        }




    }
}
