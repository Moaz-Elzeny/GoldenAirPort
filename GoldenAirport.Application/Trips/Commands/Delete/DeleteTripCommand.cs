using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Trips.Commands.Delete
{
    public class DeleteTripCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteTripHandler : IRequestHandler<DeleteTripCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteTripHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
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

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Deleted Successfully!",
                    Result = new
                    {
                        result = trip.Id
                    }
                });
            }
        }
    }
}
