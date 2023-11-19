using FluentValidation;

namespace GoldenAirport.Application.Packagess.Commands.Create
{
    public class CreatePackgeCommandValidator : AbstractValidator<CreatePackageCommand>
    {
        public CreatePackgeCommandValidator()
        {

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Package Name is required");

            RuleFor(x => x.StartingDate)
               .NotEmpty()
               .WithMessage("Starting Date is required");

            RuleFor(x => x.EndingDate)
               .NotEmpty()
               .WithMessage("Ending Date is required");

            RuleFor(x => x.AdultPrice)
               .NotEmpty()
               .WithMessage("Price is required");

            //RuleFor(x => x.CountryId)
            //  .NotEmpty()
            //  .WithMessage("Country Id is required");

            RuleFor(x => x.FromCityId)
               .NotEmpty()
               .WithMessage("From CityId is required");

            RuleFor(x => x.ToCityId)
               .NotEmpty().WithMessage("To CityId are required");
              

        }
    }
}
