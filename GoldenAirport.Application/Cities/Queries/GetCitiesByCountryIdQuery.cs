using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Employees.Queries;
using GoldenAirport.Application.Helpers.DTOs;
using System.Globalization;

namespace GoldenAirport.Application.Cities.Queries
{
    public class GetCitiesByCountryIdQuery : IRequest<ResponseDto<object>>
    {
        public int CountryId { get; set; }
        public class GetCitiesByCountryIdQueryHandler : IRequestHandler<GetCitiesByCountryIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetCitiesByCountryIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetCitiesByCountryIdQuery request, CancellationToken cancellationToken)
            {


                var cities = await _dbContext.Cities.Where(a => a.CountryId == request.CountryId)
                    .Select(d => new 
                    {
                      Id = d.Id,
                      Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? d.NameAr : d.NameEn
                    }).ToListAsync();


                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Cities",
                    Result = cities

                });
            }
        }
    }
}
