using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Helpers;

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
                        AgentCode = d.AgentCode,
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
