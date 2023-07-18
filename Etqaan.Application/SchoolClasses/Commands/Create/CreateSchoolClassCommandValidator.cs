using Etqaan.Application.SchoolClasses.Commands.CreateSchoolClass;
using FluentValidation;

namespace Etqaan.Application.SchoolClasses.Commands.Create
{
    public class CreateSchoolClassCommandValidator : AbstractValidator<CreateSchoolClassCommand>
    {
        public CreateSchoolClassCommandValidator()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage("Class name Ar is required.")
                .MaximumLength(100).WithMessage("Class name must not exceed 100 characters.");

            RuleFor(x => x.NameEn)

            .MaximumLength(100).WithMessage("Class name must not exceed 100 characters.");

            RuleFor(x => x.SchoolId)
                .NotEmpty().WithMessage("School ID is required.");

            RuleFor(x => x.SchoolGradeId)
                .NotEmpty().WithMessage("School grade ID is required.");

            RuleFor(x => x.SubjectIds)
                .NotEmpty().WithMessage("Subject IDs are required.")
                .ForEach(subjectId =>
                {
                    subjectId.NotEmpty().WithMessage("Subject ID must not be empty.");
                });
        }
    }

}
