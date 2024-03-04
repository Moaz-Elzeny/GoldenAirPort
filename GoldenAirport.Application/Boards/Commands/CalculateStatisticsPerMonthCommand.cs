using GoldenAirport.Application.Boards.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Boards.Commands
{
    public class CalculateStatisticsPerMonthCommand : IRequest<ResponseDto<object>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndtDate { get; set; }
        public string? UserId { get; set; }
        public string? CurrentUserId { get; set; }
        public class CalculateStatisticsPerMonthCommandHandler : IRequestHandler<CalculateStatisticsPerMonthCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CalculateStatisticsPerMonthCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CalculateStatisticsPerMonthCommand request, CancellationToken cancellationToken)
            {
                var trips = _dbContext.TripRegistrations.AsQueryable();
                double tripsCount = 0.0;
                var tripsPerMonths = new List<StatisticsPerMonthDto>();

                var packages = _dbContext.PackageRegistrations.AsQueryable();
                double packagesCount = 0.0;
                var packagesPerMonths = new List<StatisticsPerMonthDto>();

                double flightsCount = 18.0;

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
                    trips = trips.Where(tr => tr.CreatedById == request.CurrentUserId);
                    tripsCount = await trips.CountAsync(cancellationToken);


                    packagesPerMonths = await packages
                       .Where(tr => tr.CreatedById == request.CurrentUserId)
                       .GroupBy(tr => tr.CreationDate.Month)
                       .Select(group => new StatisticsPerMonthDto
                       {
                           Month = group.Key,
                           Count = group.Count()
                       })
                       .ToListAsync(cancellationToken);
                    packages = packages.Where(tr => tr.CreatedById == request.CurrentUserId);
                    packagesCount = await packages.CountAsync(cancellationToken);
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

                    trips = trips.Where(tr => tr.CreatedById == request.UserId);
                    tripsCount = await trips.CountAsync(cancellationToken);

                    packagesPerMonths = await packages
                      .Where(tr => tr.CreatedById == request.UserId)
                      .GroupBy(tr => tr.CreationDate.Month)
                      .Select(group => new StatisticsPerMonthDto
                      {
                          Month = group.Key,
                          Count = group.Count()
                      })
                      .ToListAsync(cancellationToken);
                    packages = packages.Where(tr => tr.CreatedById == request.UserId);
                    packagesCount = await packages.CountAsync(cancellationToken);
                }

                var TotalPercentage = flightsCount + tripsCount + packagesCount;

                var flightsPercentage = Math.Round((flightsCount / TotalPercentage) * 100);
                var tripsPercentage = Math.Round((tripsCount / TotalPercentage) * 100);
                var packagesPercentage = Math.Round((packagesCount / TotalPercentage) * 100);

                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Success ✔️",
                    Result = new
                    {
                        flightsCount,
                        flightsPercentage,
                        tripsCount,
                        tripsPercentage,
                        tripsPerMonths,
                        packagesCount,
                        packagesPercentage,
                        packagesPerMonths,
                    }
                });
            }
        }
    }
}
