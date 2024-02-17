using FluentValidation;

namespace GoldenAirport.Application.PackageRegistrations.Commands.Create
{
    public class CreatePackageRegistrationCommandValidator : AbstractValidator<CreatePackageRegistrationCommand>
    {
        public CreatePackageRegistrationCommandValidator()
        {
            RuleFor(t => t.Email)
                .EmailAddress()
                .WithMessage("Please Enter Email");

            RuleFor(t => t.PhoneNumber)
               .NotEmpty()
               .WithMessage("Please Enter Phone Number")
               .Length(11).WithMessage("Please enter an Egyptian number");

            RuleFor(t => t.PackageId)
               .NotEmpty()
               .WithMessage("Please Enter Package");
        }
    }
}
