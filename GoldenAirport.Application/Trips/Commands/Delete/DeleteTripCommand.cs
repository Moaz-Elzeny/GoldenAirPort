using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Trips.Commands.Delete
{
    public class DeleteTripCommand : IRequest<ResultDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteTripHandler : IRequestHandler<DeleteTripCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteTripHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
            {
                var trip = await _dbContext.Trips.FindAsync(request.Id) ?? throw new NotFoundException("Trip not found.");

                trip.Deleted = true;
                trip.ModificationDate = DateTime.Now;
                trip.ModifiedById = request.CurrentUserId;


                await _dbContext.SaveChangesAsync(cancellationToken);

                var visit = await _dbContext.WhyVisits.Where(x => x.TripId == request.Id).ToListAsync();
                if (visit.Count != 0)
                {
                    _dbContext.WhyVisits.RemoveRange(visit);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                var included = await _dbContext.WhatAreIncluded.Where(x => x.TripId == request.Id).ToListAsync();
                if (included.Count != 0)
                {
                    _dbContext.WhatAreIncluded.RemoveRange(included);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                var restrictions = await _dbContext.Restrictions.Where(x => x.TripId == request.Id).ToListAsync();
                if (restrictions.Count != 0)
                {
                    _dbContext.Restrictions.RemoveRange(restrictions);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                var accessibility = await _dbContext.Accessibilities.Where(x => x.TripId == request.Id).ToListAsync();
                if (accessibility.Count != 0)
                {
                    _dbContext.Accessibilities.RemoveRange(accessibility);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                return ResultDto<object>.Success(trip.Id, "Deleted has been successfully");
            }
        }
    }
}
