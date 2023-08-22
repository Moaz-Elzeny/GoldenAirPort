using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Trips.Commands.Delete
{
    public class DeleteTripCommand : IRequest<ResultDto<string>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteTripHandler : IRequestHandler<DeleteTripCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteTripHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
            {
                var trip = await _dbContext.Trips.FindAsync(request.Id) ?? throw new NotFoundException("Trip not found.");

                trip.Deleted = true;
                trip.ModificationDate = DateTime.Now;
                trip.ModifiedById = request.CurrentUserId;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Deleted has been successfully");
            }
        }
    }
}
