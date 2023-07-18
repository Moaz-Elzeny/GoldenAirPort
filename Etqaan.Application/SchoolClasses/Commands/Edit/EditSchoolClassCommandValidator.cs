using FluentValidation;

namespace Etqaan.Application.SchoolClasses.Commands.EditSchoolClass
{
    public class EditSchoolClassCommandValidator : AbstractValidator<EditSchoolClassCommand>
    {
        public EditSchoolClassCommandValidator()
        {
            RuleFor(x => x.SchoolClassId).NotEmpty().WithMessage("School class ID is required.");
            RuleFor(x => x.NameAr).MaximumLength(100).WithMessage("School class name must not exceed 100 characters.");
            RuleFor(x => x.NameEn).MaximumLength(100).WithMessage("School class name must not exceed 100 characters.");
        }
    }
}
