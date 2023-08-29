using FluentValidation;

namespace GoldenAirport.Application.Trips.Commands.Create
{
    public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
    {
        public CreateTripCommandValidator()
        {

            RuleFor(x => x.StartingDate)
               .NotEmpty()
               .WithMessage("Starting Date is required");
            
            RuleFor(x => x.EndingDate)
               .NotEmpty()
               .WithMessage("Ending Date is required");
            
            RuleFor(x => x.Price)
               .NotEmpty()
               .WithMessage("Price is required");
            
            RuleFor(x => x.Guests)
               .NotEmpty()
               .WithMessage("Guests is required");
            
            RuleFor(x => x.TripHours)
               .NotEmpty()
               .WithMessage("Trip Hours is required");
            
            RuleFor(x => x.FromCityId)
               .NotEmpty()
               .WithMessage("From CityId is required");

            RuleFor(x => x.ToCitiesIds)
               .NotEmpty().WithMessage("ToCities ID are required.")
               .ForEach(cityIds =>
               {
                   cityIds.NotEmpty().WithMessage("City ID is required.");
               });

        }
    }
}
