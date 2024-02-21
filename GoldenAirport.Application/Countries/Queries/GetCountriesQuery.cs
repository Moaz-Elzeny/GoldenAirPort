using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Countries.Dtos;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Countries.Queries
{
    public class GetCountriesQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;
        public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetCountriesHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
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
                        Code = c.Code,
                        Icon = c.Icon,
                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetCountriesDto>
                {
                    Items = countries,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All Countries",
                    Result = new
                    {
                        paginatedList
                    }
                });
            }
        }
    }
}
