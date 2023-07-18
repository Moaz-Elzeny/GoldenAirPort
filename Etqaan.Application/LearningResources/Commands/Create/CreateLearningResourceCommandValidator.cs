using FluentValidation;

namespace Etqaan.Application.LearningResources.Commands.Create
{
    public class CreateLearningResourceCommandValidator : AbstractValidator<CreateLearningResourceCommand>
    {
        public CreateLearningResourceCommandValidator()
        {
            RuleFor(a => a.NameAr).NotEmpty().WithMessage("من فضلك ادخل الاسم")
                .MaximumLength(250).WithMessage("اقصى حد للحروف : 250");

            RuleFor(a => a.NameEn).NotEmpty().WithMessage("Please Enter The Name")
                .MaximumLength(250).WithMessage("Maximum Length Of Name : 250");

            RuleFor(a => a.FilePath).NotEmpty().WithMessage("Please Enter The file");

            RuleFor(a => a.SubjectId).NotEmpty().WithMessage("Please Enter The Subject");

            RuleFor(a => a.GradeId).NotEmpty().WithMessage("Please Enter The Grade");

        }
    }
}
