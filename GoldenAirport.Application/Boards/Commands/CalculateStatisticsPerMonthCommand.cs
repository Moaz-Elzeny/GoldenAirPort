using GoldenAirport.Application.Boards.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Boards.Commands
{
    public class CalculateStatisticsPerMonthCommand : IRequest<ResponseDto<object>>
    {
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
                var tripsPerMonth = _dbContext.TripRegistrations.AsQueryable();
                var tripsCount = 0;
                var tripsPerMonths = new List<StatisticsPerMonthDto>();

                var packagesPerMonth = _dbContext.PackageRegistrations.AsQueryable();
                var packagesCount = 0;
                var packagesPerMonths = new List<StatisticsPerMonthDto>();

                var flightsCount = 18;

                if (request.UserId == null && request.CurrentUserId != null)
                {
                     tripsPerMonths = await tripsPerMonth
                        .Where(tr => tr.CreatedById == request.CurrentUserId)
                        .GroupBy(tr => tr.CreationDate.Month)
                        .Select(group => new StatisticsPerMonthDto
                        {
                            Month = group.Key,
                            Count = group.Count()
                        })
                        .ToListAsync(cancellationToken);
                    tripsPerMonth = tripsPerMonth.Where(tr => tr.CreatedById == request.CurrentUserId);
                    tripsCount = await tripsPerMonth.CountAsync(cancellationToken);


                    packagesPerMonths = await packagesPerMonth
                       .Where(tr => tr.CreatedById == request.CurrentUserId)
                       .GroupBy(tr => tr.CreationDate.Month)
                       .Select(group => new StatisticsPerMonthDto
                       {
                           Month = group.Key,
                           Count = group.Count()
                       })
                       .ToListAsync(cancellationToken);
                    packagesPerMonth = packagesPerMonth.Where(tr => tr.CreatedById == request.CurrentUserId);
                    packagesCount = await packagesPerMonth.CountAsync(cancellationToken);
                }

                if (request.UserId != null && request.CurrentUserId != null)
                {

                    tripsPerMonths = await tripsPerMonth
                       .Where(tr => tr.CreatedById == request.UserId)
                       .GroupBy(tr => tr.CreationDate.Month)
                       .Select(group => new StatisticsPerMonthDto
                       {
                           Month = group.Key,
                           Count = group.Count()
                       })
                       .ToListAsync(cancellationToken);

                    tripsPerMonth = tripsPerMonth.Where(tr => tr.CreatedById == request.UserId);
                    tripsCount = await tripsPerMonth.CountAsync(cancellationToken);

                    packagesPerMonths = await packagesPerMonth
                      .Where(tr => tr.CreatedById == request.UserId)
                      .GroupBy(tr => tr.CreationDate.Month)
                      .Select(group => new StatisticsPerMonthDto
                      {
                          Month = group.Key,
                          Count = group.Count()
                      })
                      .ToListAsync(cancellationToken);
                    packagesPerMonth = packagesPerMonth.Where(tr => tr.CreatedById == request.UserId);
                    packagesCount = await packagesPerMonth.CountAsync(cancellationToken);
                }

                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Success ✔️",
                    Result = new
                    {
                        flightsCount,
                        tripsCount,
                        tripsPerMonths,
                        packagesCount,
                        packagesPerMonths
                    }
                });
            }
        }
    }
}
