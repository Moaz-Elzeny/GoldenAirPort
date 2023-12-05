using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Trips.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetStatementQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public class GetStatementQueryHandler : IRequestHandler<GetStatementQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetStatementQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetStatementQuery request, CancellationToken cancellationToken)
            {
                var query = _dbContext.Statements
                .AsQueryable();

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 50;
                int skip = (request.PageNumber - 1) * 50;


                if (request.DateFrom != null)
                {
                    query = query.Where(t => t.CreationDate <= request.DateFrom);
                }

                if (request.DateFrom != null)
                {
                    query = query.Where(t => t.CreationDate >= request.DateTo);
                }


                var Statements = await query.Where(e => e.Employee.AppUserId == request.EmployeeId)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(x => new GetStatementDto
                    {
                        Code = x.Employee.AgentCode,
                        Day = x.CreationDate,
                        Service = x.Service,
                        Amount = x.Amount,
                    }).ToListAsync(cancellationToken);

                var totalCount =  Statements.Count();

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var paginatedList = new PaginatedList<GetTripsDto>
                {
                    Items = Statements,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Statements",
                    Result = paginatedList
                });
            }
        }
    }
}
