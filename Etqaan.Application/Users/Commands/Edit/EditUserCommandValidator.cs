using FluentValidation;

namespace Etqaan.Application.Users.Commands.EditUser
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


            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Invalid gender value.");

            RuleFor(x => x.NationalIdNumber)
                .MaximumLength(20).WithMessage("National ID number cannot exceed 20 characters.");

            RuleFor(x => x.Religion)
                .IsInEnum().WithMessage("Invalid religion value.");

            RuleFor(x => x.AddressDetails)
                .MaximumLength(250).WithMessage("Address details cannot exceed 250 characters.");



            RuleFor(x => x.UserType)
                .IsInEnum().WithMessage("Invalid user type value.");

            RuleFor(x => x.NationalityId)
                         .GreaterThan(0).WithMessage("Nationality ID must be greater than 0.");


        }




    }
}
