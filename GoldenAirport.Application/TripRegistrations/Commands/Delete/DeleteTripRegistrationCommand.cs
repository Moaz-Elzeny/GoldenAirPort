using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.TripRegistrations.Commands.Delete
{
    public class DeleteTripRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteTripRegistrationHandler : IRequestHandler<DeleteTripRegistrationCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteTripRegistrationHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(DeleteTripRegistrationCommand request, CancellationToken cancellationToken)
            {
                var trip = await _dbContext.TripRegistrations.FindAsync(request.Id) ?? throw new NotFoundException("Trip Registration not found.");

                trip.Deleted = true;
                trip.ModificationDate = DateTime.Now;
                trip.ModifiedById = request.CurrentUserId;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Deleted Successfully!",
                    Result = new
                    {
                        trip = trip.Id
                    }
                });
            }
        }
    }
}
