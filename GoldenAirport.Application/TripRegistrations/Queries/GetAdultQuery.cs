using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;

namespace GoldenAirport.Application.TripRegistrations.Queries
{
    public class GetAdultQuery : IRequest<ResponseDto<object>>
    {
        public int? TripRegistrationId { get; set; }

        public class GetAdultQueryHandler : IRequestHandler<GetAdultQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetAdultQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetAdultQuery request, CancellationToken cancellationToken)
            {
                var query = _dbContext.Adults
                    .AsQueryable();

                if (request.TripRegistrationId != 0)
                {
                    query =  query.Where(r => r.TripRegistrationId == request.TripRegistrationId);
                }

                var adult = await query
                    .Select(a => new AdultDto
                    {
                       // Id = a.Id,
                        Title = a.Title,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        AdultPassportNo = a.PassportNo,
                        DateOfBirth = a.DateOfBirth
                    }).ToListAsync();
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Adult",
                    Result = new
                    {
                        adult
                    }
                });

            }
        }
    }
}
