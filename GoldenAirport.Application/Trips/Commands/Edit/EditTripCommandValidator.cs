using FluentValidation;
using GoldenAirport.Application.Trips.Commands.Create;

namespace GoldenAirport.Application.Trips.Commands.Edit
{
    public class EditTripCommandValidator : AbstractValidator<EditTripCommand>
    {
        public EditTripCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Trip Id is required");

          
        }
    }
}
