using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Commands.Delete;

namespace GoldenAirport.Application.PackageRegistrations.Commands.Delete
{
    public class ApprovePackageRegistrationDeletingCommand : IRequest<ResponseDto<object>>
    {
        public int TripRegistrationId { get; set; }
        public bool Approve { get; set; }
        public string? CurrentUserId { get; set; }

        public class ApprovePackageRegistrationDeletingCommandHandler : IRequestHandler<ApprovePackageRegistrationDeletingCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public ApprovePackageRegistrationDeletingCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(ApprovePackageRegistrationDeletingCommand request, CancellationToken cancellationToken)
            {
                var PackageRegistrationDeleting = await _dbContext.PackageRegistrationsDeleting.Where(tr => tr.PackageRegistrationId == request.TripRegistrationId).FirstOrDefaultAsync() ?? throw new Exception("Trip Registration not found");

                if (request.Approve)
                {
                    var PackageRegistrations = new DeletePackageRegistrationCommand
                    {
                        Id = request.TripRegistrationId,
                        CurrentUserId = request.CurrentUserId,
                    };
                    await _mediator.Send(PackageRegistrations);

                    _dbContext.PackageRegistrationsDeleting.RemoveRange(PackageRegistrationDeleting);

                    var Notification = new Domain.Entities.Notification
                    {
                        Title = "The trip Deletion request has been approved",
                        Date = DateTime.Now,
                        Content = "",
                        AppUserId = PackageRegistrationDeleting.CreatedById
                    };
                    await _dbContext.Notifications.AddAsync(Notification);

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Deleted Successfully!",
                        Result = PackageRegistrationDeleting.Id
                    });
                }

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Deleted Unacceptable!",
                    Result = PackageRegistrationDeleting.Id
                });

            }
        }
    }
}
