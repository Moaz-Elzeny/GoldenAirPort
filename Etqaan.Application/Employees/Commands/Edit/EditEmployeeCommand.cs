using Etqaan.Application.Common.Models;
using Etqaan.Application.Users.Commands.EditUser;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

public class EditEmployeeCommand : IRequest<ResultDto<string>>
{
    public string? EmployeeId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public string? NationalIdNumber { get; set; }
    public Religion? Religion { get; set; }
    public string? AddressDetails { get; set; }
    public IFormFile? ProfilePicture { get; set; }
    public UserType? UserType { get; set; }
    public int? NationalityId { get; set; }
    public string? JobTitle { get; set; }
    public byte? YearsOfExperience { get; set; }
    public JobType? JobType { get; set; }
    public decimal? Salary { get; set; }
    public int? BankId { get; set; }
    public string? BankAccountNumber { get; set; }
    public string? IBAN { get; set; }
    public string? CurrentUserId { get; set; }

    public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, ResultDto<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMediator _mediator;

        public EditEmployeeCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<ResultDto<string>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FindAsync(request.EmployeeId, cancellationToken);

            if (employee == null)
            {
                return ResultDto<string>.Failure("Employee not found.");
            }

            // Update User Of Employee
            var editUserCommand = new EditUserCommand
            {
                UserId = employee.AppUserId,
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                NationalIdNumber = request.NationalIdNumber,
                Religion = request.Religion,
                AddressDetails = request.AddressDetails,
                UserType = request.UserType,
                NationalityId = request.NationalityId,
                CurrentUserId = request.CurrentUserId,
                PhoneNumber = request.PhoneNumber,
                ProfilePicture = request.ProfilePicture
            };

            await _mediator.Send(editUserCommand, cancellationToken);

            // Update employee data
            if (request.JobTitle != null)
                employee.JobTitle = request.JobTitle;

            if (request.YearsOfExperience != null)
                employee.YearsOfExperience = request.YearsOfExperience.Value;

            if (request.JobType != null)
                employee.JobType = request.JobType.Value;

            if (request.Salary != null)
                employee.Salary = request.Salary.Value;

            if (request.BankId != null)
                employee.BankId = request.BankId.Value;

            if (request.BankAccountNumber != null)
                employee.BankAccountNumber = request.BankAccountNumber;

            if (request.IBAN != null)
                employee.IBAN = request.IBAN;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return ResultDto<string>.Success("Employee Updated Successfully!");
        }
    }
}
