using Etqaan.Application.Common.Models;
using Etqaan.Application.Users.Commands.CreateUser;
using Etqaan.Domain.Entities;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand : IRequest<ResultDto<string>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string NationalIdNumber { get; set; }
        public Religion Religion { get; set; }
        public string? AddressDetails { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public UserType UserType { get; set; }
        public int NationalityId { get; set; }
        public string? CurrentUserId { get; set; }
        public string JobTitle { get; init; }
        public byte YearsOfExperience { get; init; }
        public JobType JobType { get; init; }
        public decimal Salary { get; init; }
        public int BankId { get; init; }
        public string BankAccountNumber { get; init; }
        public string IBAN { get; init; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public CreateEmployeeCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResultDto<string>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                // Create user for the employee
                var createUserCommand = new CreateUserCommand
                {
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
                    Password = request.Password,
                    ProfilePicture = request.ProfilePicture,
                };

                var createUserResult = await _mediator.Send(createUserCommand, cancellationToken);


                // Create the employee
                var employee = new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    AppUserId = createUserResult.Data.UserId,
                    JobTitle = request.JobTitle,
                    YearsOfExperience = request.YearsOfExperience,
                    JobType = request.JobType,
                    Salary = request.Salary,
                    BankId = request.BankId,
                    BankAccountNumber = request.BankAccountNumber,
                    IBAN = request.IBAN,
                    CreatedById = "EtqaanAdmin",
                    CreationDate = DateTime.Now,

                };

                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success(employee.Id);
            }
        }
    }
}
