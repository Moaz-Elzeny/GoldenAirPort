using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Users.Commands.CreateUser;
using GoldenAirport.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Employees.Commands.Create
{
    public class CreateEmployeeCommand : IRequest<ResponseDto<object>>
    {

        //public string AppUserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile ProfilePicture { get; set; }

        public string? CurrentUserId { get; set; }
        //public decimal ServiceFees { get; set; }
        //public int AgentCode { get; set; }
        //public DateTime Date { get; set; }
        //public paymentMethod PaymentMethod { get; set; }
        public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public CreateEmployeeHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                //var user = await _dbContext.AppUsers
                //    .Where(u => u.Id == request.AppUserId && u.UserType == Domain.Enums.UserType.Employee)
                //    .FirstOrDefaultAsync() ?? throw new Exception("Employee Not Found");

                //Create user for the employee
                var CreateUser = new CreateUserCommand()
                {
                    Email = request.Email,
                    Password = request.Password,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    UserType = Domain.Enums.UserType.Employee,
                    
                    ProfilePicture = request.ProfilePicture,
                    CurrentUserId = request.CurrentUserId,

                };
                var result = await _mediator.Send(CreateUser, cancellationToken);

                //Create the employee
                var CreateEmployee = new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    AppUserId = result.Result.Message,                    
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                    Active = true

                };

                _dbContext.Employees.Add(CreateEmployee);
                await _dbContext.SaveChangesAsync(cancellationToken);

                
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully",
                    Result = new
                    {
                        Employee = CreateEmployee.Id
                    }
                });

            }
        }
    }
}
