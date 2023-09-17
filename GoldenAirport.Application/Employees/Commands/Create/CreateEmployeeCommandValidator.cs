using FluentValidation;

namespace GoldenAirport.Application.Employees.Commands.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.AgentCode)
                .NotEmpty()
                .WithMessage("Agent Code is required");

            RuleFor(x => x.Balance)
                .NotEmpty()
                .WithMessage("Balance is required");

            RuleFor(x => x.Target)
                .NotEmpty()
                .WithMessage("Target  is required");

            RuleFor(x => x.PaymentMethod)
                .IsInEnum()
                .WithMessage("Invalid Payment Method Value");
        }
    }
}
