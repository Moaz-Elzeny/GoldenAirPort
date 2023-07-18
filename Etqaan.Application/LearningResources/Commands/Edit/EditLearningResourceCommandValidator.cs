using FluentValidation;

namespace Etqaan.Application.LearningResources.Commands.Edit
{
    public class EditLearningResourceCommandValidator : AbstractValidator<EditLearningResourceCommand>
    {
        public EditLearningResourceCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Resource Id is required");
        }
    }
}
