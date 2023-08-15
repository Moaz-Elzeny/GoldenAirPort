using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Users.Commands.CreateUser;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Employees.Commands.Create
{
    public class CreateEmployeeCommand : IRequest<ResultDto<string>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public decimal ServiceFees { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string? CurrentUserId { get; set; }
        public int AgentCode { get; set; }
        public decimal Balance { get; set; }
        public decimal DailyGoal { get; set; }
        public paymentMethod PaymentMethod { get; set; }
        public DateTime LastLogin { get; set; }
        public string AppUserId { get; set; }
        public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public CreateEmployeeHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResultDto<string>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                //Create user for the employee
                var CreateUser = new CreateUserCommand()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    UserType = request.UserType,
                    ServiceFees = request.ServiceFees,
                    ProfilePicture = request.ProfilePicture,
                    CurrentUserId = request.CurrentUserId,

                };
                    var result = await _mediator.Send(CreateUser, cancellationToken);

                //Create the employee
                var CreateEmployee = new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    AppUserId = result.Data.UserId,
                    AgentCode = request.AgentCode,
                    Balance = request.Balance,
                    DailyGoal = request.DailyGoal,
                    PaymentMethod = request.PaymentMethod,
                    LastLogin = request.LastLogin,  //Edit

                };
                return ResultDto<string>.Success(CreateEmployee.Id);

            }
        }
    }
}
