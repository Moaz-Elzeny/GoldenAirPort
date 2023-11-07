using FluentValidation;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditEmployeeCommandValidator : AbstractValidator<EditEmployeeCommand>
    {
        public EditEmployeeCommandValidator()
        {
            //RuleFor(x => x.Email)
            //   .EmailAddress().WithMessage("Invalid email format.");

            //RuleFor(x => x.FirstName)
            //    .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

            //RuleFor(x => x.LastName)
            //    .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.");

            //RuleFor(x => x.PhoneNumber)
            //    .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");

            //RuleFor(x => x.UserType)
            //    .IsInEnum().WithMessage("Invalid user type value.");

            //RuleFor(x => x.AgentCode)
            //   .NotEmpty()
            //   .WithMessage("Agent Code is required");

            //RuleFor(x => x.Balance)
            //    .NotEmpty()
            //    .WithMessage("Balance is required");

            //RuleFor(x => x.DailyGoal)
            //    .NotEmpty()
            //    .WithMessage("Daily Goal is required");

            //RuleFor(x => x.PaymentMethod)
            //    .IsInEnum()
            //    .WithMessage("Invalid Payment Method Value");
        }
    }
}
