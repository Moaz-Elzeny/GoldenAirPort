using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Boards.Queries
{
    public class GetCountStatisticsQuery : IRequest<ResponseDto<object>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndtDate { get; set; }
        public string? UserId { get; set; }
        public string? CurrentUserId { get; set; }
        public class GetCountStatisticsQueryHandler : IRequestHandler<GetCountStatisticsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetCountStatisticsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetCountStatisticsQuery request, CancellationToken cancellationToken)
            {
                var trips = _dbContext.TripRegistrations.AsQueryable();
                double tripsCount = 0.0;

                var packages = _dbContext.PackageRegistrations.AsQueryable();
                double packagesCount = 0.0;

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
                    trips = trips.Where(tr => tr.CreatedById == request.CurrentUserId);
                    tripsCount = await trips.CountAsync(cancellationToken);

                    packages = packages.Where(tr => tr.CreatedById == request.CurrentUserId);
                    packagesCount = await packages.CountAsync(cancellationToken);
                }

                if (request.UserId != null && request.CurrentUserId != null)
                {
                    trips = trips.Where(tr => tr.CreatedById == request.UserId);
                    tripsCount = await trips.CountAsync(cancellationToken);


                    packages = packages.Where(tr => tr.CreatedById == request.UserId);
                    packagesCount = await packages.CountAsync(cancellationToken);
                }

                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Success ✔️",
                    Result = new
                    {
                        flightsCount,
                        tripsCount,                       
                        packagesCount,                       
                    }
                });
            }
        }
    }
}
