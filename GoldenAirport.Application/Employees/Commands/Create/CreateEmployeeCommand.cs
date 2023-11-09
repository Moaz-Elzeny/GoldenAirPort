using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Employees.Commands.Create
{
    public class CreateEmployeeCommand : IRequest<ResponseDto<object>>
    {

        public string AppUserId { get; set; }
        public decimal ServiceFees { get; set; }
        public string? CurrentUserId { get; set; }
        //public int AgentCode { get; set; }
        //public DateTime Date { get; set; }
        //public paymentMethod PaymentMethod { get; set; }
        public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateEmployeeHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var user = await _dbContext.AppUsers
                    .Where(u => u.Id == request.AppUserId && u.UserType == Domain.Enums.UserType.Employee)
                    .FirstOrDefaultAsync() ?? throw new Exception("Employee Not Found");

                var random = new Random();
                int randomNumber = random.Next();

                //Create the employee
                var CreateEmployee = new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    AppUserId = request.AppUserId,
                    AgentCode = randomNumber,
                    ServiceFees = request.ServiceFees,
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
