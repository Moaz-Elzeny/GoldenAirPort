using FluentValidation;

namespace GoldenAirport.Application.TripRegistrations.Commands.Create
{
    public class CreateTripRegistrationCommandValidator : AbstractValidator<CreateTripRegistrationCommand>
    {
        public CreateTripRegistrationCommandValidator()
        {         
            RuleFor(t => t.Email)
                .EmailAddress()
                .WithMessage("Please Enter Email");

            RuleFor(t => t.PhoneNumber)
               .NotEmpty()
               .WithMessage("Please Enter Phone Number")
               .Length(11).WithMessage("Please enter an Egyptian number");

            RuleFor(t => t.TripId)
               .NotEmpty()
               .WithMessage("Please Enter Trip");
        }
    }
}
