using GoldenAirport.Application.Cities.Dtos;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Countries.Dtos;
using GoldenAirport.Application.Helpers;
using System.Globalization;

namespace GoldenAirport.Application.Cities.Queries
{
    public class GetCitiesQuery : IRequest<ResultDto<PaginatedList<GetCitiesDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, ResultDto<PaginatedList<GetCitiesDto>>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetCitiesHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<PaginatedList<GetCitiesDto>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
            {

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.Cities
                .AsQueryable();

                var totalCount = await query.CountAsync(cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var countries = await query
                    .Select(c => new GetCitiesDto
                    {
                        Id = c.Id,
                        NameAr = c.NameAr,
                        NameEn = c.NameEn,
                        CountryId = c.CountryId,
                        CountryName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.Country.NameAr : c.Country.NameEn,
                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetCitiesDto>
                {
                    Items = countries,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResultDto<PaginatedList<GetCitiesDto>>.Success(paginatedList);
            }
        }
    }
}
