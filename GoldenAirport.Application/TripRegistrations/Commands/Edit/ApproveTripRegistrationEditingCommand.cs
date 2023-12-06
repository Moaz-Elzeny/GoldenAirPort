using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.TripRegistrations.Commands.Edit
{
    public class ApproveTripRegistrationEditingCommand : IRequest<ResponseDto<object>>
    {
        public int TripRegistrationId { get; set; }
        public bool Approve { get; set; }
        public string? CurrentUserId { get; set; }

        public class ApproveTripRegistrationEditingCommandHandler : IRequestHandler<ApproveTripRegistrationEditingCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public ApproveTripRegistrationEditingCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(ApproveTripRegistrationEditingCommand request, CancellationToken cancellationToken)
            {
                var TripRegistrationEditing = await _dbContext.TripRegistrationsEditing.Include(a => a.AdultsEditing).Include(c => c.ChildrenEditing)
                    .Where(p => p.TripRegistrationId == request.TripRegistrationId).FirstOrDefaultAsync() ?? throw new Exception("Trip Registration not found");

                var TripRegistration = await _dbContext.TripRegistrations.Include(a => a.Adults).Include(c => c.Children)
                    .Where(p => p.Id == request.TripRegistrationId).FirstOrDefaultAsync() ?? throw new Exception("Trip Registration not found");

                if (request.Approve)
                {
                    TripRegistration.AdultCost = TripRegistration.AdultCost;
                    TripRegistration.ChildCost = TripRegistration.ChildCost;
                    TripRegistration.AdminFees = TripRegistration.AdminFees;
                    TripRegistration.EmployeeFees = TripRegistration.EmployeeFees;
                    TripRegistration.Taxes = TripRegistration.Taxes;
                    TripRegistration.Email = TripRegistrationEditing.Email;
                    TripRegistration.PhoneNumber = TripRegistrationEditing.PhoneNumber;
                    TripRegistration.TripId = TripRegistration.TripId;
                    TripRegistration.ModifiedById = request.CurrentUserId;
                    TripRegistration.ModificationDate = DateTime.Now;

                    if (TripRegistrationEditing.AdultsEditing.Count != 0)
                    {

                        _dbContext.Adults.RemoveRange(TripRegistration.Adults);

                        foreach (var item in TripRegistrationEditing.AdultsEditing)
                        {

                            TripRegistration.Adults.Add(new Adult()
                            {
                                Title = item.Title,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                PassportNo = item.PassportNo,
                                DateOfBirth = DateTime.Now,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            });
                        }

                    }


                    //child
                    if (TripRegistrationEditing.ChildrenEditing.Count != 0)
                    {
                        _dbContext.Children.RemoveRange(TripRegistration.Children);

                        foreach (var item in TripRegistrationEditing.ChildrenEditing)
                        {

                            TripRegistration.Children.Add(new Child()
                            {
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                PassportNo = item.PassportNo,
                                DateOfBirth = DateTime.Now,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            });
                        }

                    }

                    _dbContext.TripRegistrationsEditing.RemoveRange(TripRegistrationEditing);

                    var Notification = new Notification
                    {
                        Title = "The trip modification request has been approved",
                        Date = DateTime.Now,
                        Content = "",
                        AppUserId = TripRegistrationEditing.CreatedById
                    };
                    await _dbContext.Notifications.AddAsync(Notification);

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Updated Successfully!",
                        Result = TripRegistration.Id
                    });
                }

                _dbContext.TripRegistrationsEditing.RemoveRange(TripRegistrationEditing);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Unacceptable!",
                    Result = TripRegistration.Id
                });
            }
        }
    }
}
