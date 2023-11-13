using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<ResponseDto<object>>
    {
        public string Id { get; set; }
        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetEmployeeByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            {


                var employeeDetails = await _dbContext.Employees.Where(a => a.Id == request.Id)
                    .Select(d => new EmployeeByIdDto
                    {
                        ProfilePicture = d.AppUser.ProfilePicture,
                        FirstName = d.AppUser.FirstName,
                        LastName = d.AppUser.LastName,  
                        Email = d.AppUser.Email,
                        PhoneNumber = d.AppUser.PhoneNumber,
                        AgentCode = d.AgentCode,
                        //Balance = d.Balance.BalanceAmount,
                        Target = d.DailyGoals.Where(e => e.EmployeeId == request.Id).Select(a => a.Target).FirstOrDefault(),
                        ServiceFees = d.ServiceFees,
                        IsActive = d.Active,
                        LastLogin = d.LastLogin,
                        
                    }).ToListAsync();


                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All employee",
                    Result = new
                    {
                        Employees = employeeDetails
                    }
                });
            }
        }
    }
}
