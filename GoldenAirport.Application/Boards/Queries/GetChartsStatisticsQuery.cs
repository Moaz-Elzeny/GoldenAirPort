using GoldenAirport.Application.Boards.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Boards.Queries
{
    public class GetChartsStatisticsQuery : IRequest<ResponseDto<object>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndtDate { get; set; }
        public string? UserId { get; set; }
        public string? CurrentUserId { get; set; }
        public class GetChartsStatisticsQueryHandler : IRequestHandler<GetChartsStatisticsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetChartsStatisticsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetChartsStatisticsQuery request, CancellationToken cancellationToken)
            {
                var trips = _dbContext.TripRegistrations.AsQueryable();
                var tripsPerMonths = new List<StatisticsPerMonthDto>();

                var packages = _dbContext.PackageRegistrations.AsQueryable();
                var packagesPerMonths = new List<StatisticsPerMonthDto>();


                if (request.StartDate != null)
                {
                    trips = trips.Where(d => d.CreationDate >= request.StartDate);
                    packages = packages.Where(d => d.CreationDate >= request.StartDate);
                }

                if (request.EndtDate != null)
                {
                    trips = trips.Where(d => d.CreationDate <= request.EndtDate);
                    packages = packages.Where(d => d.CreationDate <= request.EndtDate);
                }



                if (request.UserId == null && request.CurrentUserId != null)
                {
                    tripsPerMonths = await trips
                       .Where(tr => tr.CreatedById == request.CurrentUserId)
                       .GroupBy(tr => tr.CreationDate.Month)
                       .Select(group => new StatisticsPerMonthDto
                       {
                           Month = group.Key,
                           Count = group.Count()
                       })
                       .ToListAsync(cancellationToken);

                    packagesPerMonths = await packages
                       .Where(tr => tr.CreatedById == request.CurrentUserId)
                       .GroupBy(tr => tr.CreationDate.Month)
                       .Select(group => new StatisticsPerMonthDto
                       {
                           Month = group.Key,
                           Count = group.Count()
                       })
                       .ToListAsync(cancellationToken);
                }


                if (request.UserId != null && request.CurrentUserId != null)
                {

                    tripsPerMonths = await trips
                       .Where(tr => tr.CreatedById == request.UserId)
                       .GroupBy(tr => tr.CreationDate.Month)
                       .Select(group => new StatisticsPerMonthDto
                       {
                           Month = group.Key,
                           Count = group.Count()
                       })
                       .ToListAsync(cancellationToken);

                    packagesPerMonths = await packages
                      .Where(tr => tr.CreatedById == request.UserId)
                      .GroupBy(tr => tr.CreationDate.Month)
                      .Select(group => new StatisticsPerMonthDto
                      {
                          Month = group.Key,
                          Count = group.Count()
                      })
                      .ToListAsync(cancellationToken);
                }

                var flightsPerMonths = new List<StatisticsPerMonthDto>
                {
                    new StatisticsPerMonthDto
                    {
                      Month = 6,
                      Count = 3
                    },
                    new StatisticsPerMonthDto
                    {
                        Month = 8,
                        Count = 4
                    }
                };

                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Success ✔️",
                    Result = new
                    {
                        flightsPerMonths,
                        tripsPerMonths,
                        packagesPerMonths,
                    }
                });
            }
        }
    }
}
