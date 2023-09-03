using FluentValidation;
using GoldenAirport.Application.Trips.Commands.Edit;

namespace GoldenAirport.Application.Packagess.Commands.Edit
{
    public class EditPackageCommandValidator : AbstractValidator<EditPackageCommand>
    {
        public EditPackageCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Package Id is required");


        }
    }
}
