using FluentValidation;

namespace GoldenAirport.Application.TripRegistrations.Commands.Edit
{
    public class EditTripRegistrationCommandValidator : AbstractValidator<EditTripRegistrationCommand>
    {
        public EditTripRegistrationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Trip Registration Id is required");

        }
    }
}
