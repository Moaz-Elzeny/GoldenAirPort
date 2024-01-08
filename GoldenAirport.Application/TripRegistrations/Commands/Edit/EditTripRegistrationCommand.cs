using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.RegistrationsEditing.Commands.Edit;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.TripRegistrations.Commands.Edit
{
    public class EditTripRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }        
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? TripId { get; set; }

        public List<AdultDto>? Adults { get; set; }
        public List<ChildDto>? Children { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditTripRegistrationHandler : IRequestHandler<EditTripRegistrationCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public EditTripRegistrationHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(EditTripRegistrationCommand request, CancellationToken cancellationToken)
            {
                var user = _dbContext.AppUsers.Where(a => a.Id == request.CurrentUserId).FirstOrDefault();

                var tripRegistration = await _dbContext.TripRegistrations
                    .Include(a => a.Adults)
                    .Include(a => a.Children)
                    .FirstOrDefaultAsync(t => t.Id == request.Id) ?? throw new NotFoundException("Trip Registration not found.");

                if (user.UserType == UserType.SuperAdmin)
                {
                    
                    tripRegistration.Email = request.Email ?? tripRegistration.Email;
                    tripRegistration.PhoneNumber = request.PhoneNumber ?? tripRegistration.PhoneNumber;

                    if (request.TripId != 0)
                    {
                        tripRegistration.TripId = request.TripId.Value;
                    }

                    tripRegistration.ModifiedById = request.CurrentUserId;
                    tripRegistration.ModificationDate = DateTime.Now;

                    if (request.Adults.Count != 0)
                    {
                        _dbContext.Adults.RemoveRange(tripRegistration.Adults);
                        foreach (var item in request.Adults)
                        {
                            tripRegistration.Adults.Add(new Adult()
                            {
                                Title = item.Title.Value,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                PassportNo = item.PassportNo,
                                DateOfBirth = item.DateOfBirth.Value,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            });
                        }

                    }

                    //child
                    if (request.Children.Count != 0 )
                    {
                        _dbContext.Children.RemoveRange(tripRegistration.Children);
                        foreach (var item in request.Children)
                        {
                            tripRegistration.Children.Add(new Child()
                            {
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                PassportNo = item.PassportNo,
                                DateOfBirth = item.DateOfBirth.Value,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            });
                        }

                    }
                }
                else
                {
                    var TripRegistrationEditing = new TripRegistrationEditingCommand
                    {
                        TripRegistrationId = request.Id,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        Adults = request.Adults,
                        Children = request.Children,
                        CurrentUserId = request.CurrentUserId,
                    };
                    await _mediator.Send(TripRegistrationEditing);
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully!",
                    Result =  tripRegistration.Id
                });
            }
        }
    }
}
