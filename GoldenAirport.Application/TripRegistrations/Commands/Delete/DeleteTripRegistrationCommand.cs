using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.TripRegistrations.Commands.Delete
{
    public class DeleteTripRegistrationCommand : IRequest<ResultDto<string>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteTripRegistrationHandler : IRequestHandler<DeleteTripRegistrationCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteTripRegistrationHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(DeleteTripRegistrationCommand request, CancellationToken cancellationToken)
            {
                var trip = await _dbContext.TripRegistrations.FindAsync(request.Id) ?? throw new NotFoundException("Trip Registration not found.");

                trip.Deleted = true;
                trip.ModificationDate = DateTime.Now;
                trip.ModifiedById = request.CurrentUserId;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Deleted has been successfully");
            }
        }
    }
}
