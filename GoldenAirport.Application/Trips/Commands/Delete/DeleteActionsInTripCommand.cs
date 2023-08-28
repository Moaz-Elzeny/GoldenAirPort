using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Trips.Commands.Delete
{
    public class DeleteActionsInTripCommand : IRequest<ResultDto<string>>
    {
        public int TripId { get; set; }
        public int? WhyVisitId { get; set; }
        public int? WhatIncludedId { get; set; }
        public int? AccessibilityId { get; set; }
        public int? RestrictionId { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteActionsInTripHandler : IRequestHandler<DeleteActionsInTripCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteActionsInTripHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(DeleteActionsInTripCommand request, CancellationToken cancellationToken)
            {
                var trip = await _dbContext.Trips.FindAsync(request.TripId) ?? throw new NotFoundException("Trip not found.");

                if (request.WhyVisitId != null)
                {
                    var visit = await _dbContext.WhyVisits.Where(x => x.TripId == request.TripId && x.Id == request.WhyVisitId).FirstOrDefaultAsync();
                    if (visit != null)
                    {
                        _dbContext.WhyVisits.Remove(visit);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }

                }

                if (request.WhatIncludedId != null)
                {
                    var included = await _dbContext.WhatAreIncluded.Where(x => x.TripId == request.TripId && x.Id == request.WhatIncludedId).FirstOrDefaultAsync();
                    if (included != null)
                    {
                        _dbContext.WhatAreIncluded.Remove(included);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }
                }

                if (request.RestrictionId != null)
                {
                    var restrictions = await _dbContext.Restrictions.Where(x => x.TripId == request.TripId && x.Id == request.RestrictionId).FirstOrDefaultAsync();
                    if (restrictions != null)
                    {
                        _dbContext.Restrictions.Remove(restrictions);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }
                }

                if (request.AccessibilityId != null)
                {
                    var accessibility = await _dbContext.Accessibilities.Where(x => x.TripId == request.TripId && x.Id == request.AccessibilityId).FirstOrDefaultAsync();
                    if (accessibility != null)
                    {
                        _dbContext.Accessibilities.Remove(accessibility);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }
                }
                return ResultDto<string>.Success("Deleted has been successfully");
            }
        }
    }
}
