using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Employees.Commands.Create
{
    public class CreateEmployeeCommand : IRequest<ResultDto<object>>
    {

        public string AppUserId { get; set; }
        public string? CurrentUserId { get; set; }
        public int AgentCode { get; set; }
        public decimal DailyGoal { get; set; }
        public decimal Target { get; set; }
        public DateTime Date { get; set; }
        //public paymentMethod PaymentMethod { get; set; }
        public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateEmployeeHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var user = await _dbContext.AppUsers
                    .Where(u => u.Id == request.AppUserId && u.UserType == Domain.Enums.UserType.Employee)
                    .FirstOrDefaultAsync() ?? throw new Exception("Employee Not Found");

                //Create the employee
                var CreateEmployee = new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    AppUserId = request.AppUserId,
                    AgentCode = request.AgentCode,
                    Target = request.Target,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                    Active = true

                };

                _dbContext.Employees.Add(CreateEmployee);
                await _dbContext.SaveChangesAsync(cancellationToken);

                
                return ResultDto<object>.Success(CreateEmployee.Id, "Created Successfully");

            }
        }
    }
}
