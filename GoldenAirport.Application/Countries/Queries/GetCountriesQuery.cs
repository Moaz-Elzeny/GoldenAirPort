using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Countries.Dtos;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GoldenAirport.Application.Countries.Queries
{
    public class GetCountriesQuery : IRequest<ResultDto<PaginatedList<GetCountriesDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, ResultDto<PaginatedList<GetCountriesDto>>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetCountriesHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<PaginatedList<GetCountriesDto>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
            {

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.Countries
                .AsQueryable();

                var totalCount = await query.CountAsync(cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var countries = await query
                    .Select(c => new GetCountriesDto
                    {
                        Id = c.Id,
                        NameAr = c.NameAr,
                        NameEn = c.NameEn,
                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetCountriesDto>
                {
                    Items = countries,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResultDto<PaginatedList<GetCountriesDto>>.Success(paginatedList);
            }
        }
    }
}
