using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.TripRegistrations.Commands.Delete
{
    public class ApproveTripRegistrationDeletingCommand : IRequest<ResponseDto<object>>
    {
        public int TripRegistrationId { get; set; }
        public bool Approve { get; set; }
        public string? CurrentUserId { get; set; }

        public class ApproveTripRegistrationDeletingCommandHandler : IRequestHandler<ApproveTripRegistrationDeletingCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public ApproveTripRegistrationDeletingCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(ApproveTripRegistrationDeletingCommand request, CancellationToken cancellationToken)
            {
                var TripRegistrationDeleting = await _dbContext.TripRegistrationsDeleting.Where(tr => tr.TripRegistrationId == request.TripRegistrationId).FirstOrDefaultAsync() ?? throw new Exception("Trip Registration not found");

                if (request.Approve)
                {
                    var TripRegistrations = new DeleteTripRegistrationCommand
                    {
                        Id = request.TripRegistrationId,
                        CurrentUserId = request.CurrentUserId,
                    };
                    await _mediator.Send(TripRegistrations);

                    _dbContext.TripRegistrationsDeleting.RemoveRange(TripRegistrationDeleting);

                    var Notification = new Notification
                    {
                        Title = "The trip Deletion request has been approved",
                        Date = DateTime.Now,
                        Content = "",
                        AppUserId = TripRegistrationDeleting.CreatedById
                    };
                    await _dbContext.Notifications.AddAsync(Notification);

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Deleted Successfully!",
                        Result = TripRegistrationDeleting.Id
                    });
                }

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Deleted Unacceptable!",
                    Result = TripRegistrationDeleting.Id
                });

            }
        }
    }
}