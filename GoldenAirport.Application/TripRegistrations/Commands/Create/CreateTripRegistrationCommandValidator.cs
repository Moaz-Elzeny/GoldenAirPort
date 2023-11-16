using FluentValidation;

namespace GoldenAirport.Application.TripRegistrations.Commands.Create
{
    public class CreateTripRegistrationCommandValidator : AbstractValidator<CreateTripRegistrationCommand>
    {
        public CreateTripRegistrationCommandValidator()
        {
            //RuleFor(t => t.AdminFees)
            //    .NotEmpty()
            //    .WithMessage("Please Enter The Package Cost");

            //RuleFor(t => t.TaxesAndFees)
            //   .NotEmpty()
            //   .WithMessage("Please Enter Taxes And Fees");

            RuleFor(t => t.Email)
                .EmailAddress()
                .WithMessage("Please Enter Email");

            RuleFor(t => t.PhoneNumber)
               .NotEmpty()
               .WithMessage("Please Enter Phone Number")
               .MaximumLength(15).WithMessage("Maximum Length for Phone Number is: 15");

            RuleFor(t => t.TripId)
               .NotEmpty()
               .WithMessage("Please Enter Trip Id");
        }
    }
}
