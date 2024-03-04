using GoldenAirport.Application.Boards.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using System.Globalization;

namespace GoldenAirport.Application.Boards.Queries
{
    public class GetAirportsQuery : IRequest<ResponseDto<object>> 
    {
        public class GetAirportsQueryCommandHandler : IRequestHandler<GetAirportsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetAirportsQueryCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetAirportsQuery request, CancellationToken cancellationToken)
            {
                var query = _dbContext.Airports.AsQueryable();

                var airports = await query.Select(a => new AirportDto
                {
                    Id = a.Id,
                    Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? a.NameAr : a.NameEn,
                    Code = a.Code,
                }).ToListAsync();

                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Success ✔️",
                    Result = airports
                });
            }
        }
    }
}
