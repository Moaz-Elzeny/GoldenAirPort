using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Helpers;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetAllEmployeeQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;
        public string? SearchKey { get; set; }

        public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetAllEmployeeHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {
                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.Employees
                .AsQueryable();

                if (!string.IsNullOrEmpty(request.SearchKey))
                {
                    query = query.Where(e =>
                        e.AppUser.FirstName.Contains(request.SearchKey) ||
                        e.AppUser.LastName.Contains(request.SearchKey) ||
                        e.AppUser.PhoneNumber.Contains(request.SearchKey)
                    );
                }

                var totalCount = await query.CountAsync(cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);


                var employees = await query
                    .Select(x => new GetAllEmployeeDto
                    {
                        Id = x.Id,
                        Email = x.AppUser.Email,
                        UserName = x.AppUser.UserName,
                        FirstName = x.AppUser.FirstName,
                        LastName = x.AppUser.LastName,
                        PhoneNumber = x.AppUser.PhoneNumber,
                        UserType = x.AppUser.UserType,
                        //ServiceFees = x.AppUser.ServiceFees,
                        ProfilePicture = x.AppUser.ProfilePicture.ToString(),
                        IsActive = x.Active,
                        AgentCode = x.AgentCode,
                        Balance = x.Balance.BalanceAmount,
                        //DailyGoal = x.DailyGoal,
                        ServiceFees = x.ServiceFees,
                        //Date = x.Date,
                        //PaymentMethod = x.PaymentMethod,
                        LastLogin = x.LastLogin,
                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetAllEmployeeDto>
                {
                    Items = employees,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All employee",
                    Result = new
                    {
                        Employees = paginatedList
                    }
                });
            }
        }
    }
}
