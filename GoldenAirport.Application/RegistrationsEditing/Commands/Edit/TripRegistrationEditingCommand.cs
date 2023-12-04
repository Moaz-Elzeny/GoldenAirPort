using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.RegistrationsEditing.Commands.Edit
{
    public class TripRegistrationEditingCommand : IRequest<ResponseDto<object>>
    {
        public int TripRegistrationId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<AdultDto>? Adults { get; set; }
        public List<ChildDto>? Children { get; set; }
        public string? CurrentUserId { get; set; }

        public class TripRegistrationEditingCommandHandler : IRequestHandler<TripRegistrationEditingCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public TripRegistrationEditingCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(TripRegistrationEditingCommand request, CancellationToken cancellationToken)
            {

                var tripRegistration = new TripRegistrationEditing
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    TripRegistrationId = request.TripRegistrationId,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now

                };

                _dbContext.TripRegistrationsEditing.Add(tripRegistration);



                if (request.Adults.Count != 0)
                {
                    foreach (var item in request.Adults)
                    {
                        tripRegistration.AdultsEditing.Add(new AdultEditing()
                        {
                            Title = item.Title.Value,
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
                if (request.Children.Count != 0)
                {

                    foreach (var item in request.Children)
                    {
                        tripRegistration.ChildrenEditing.Add(new ChildEditing()
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

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "The request for amendment from the admin is being followed up",
                    Result = tripRegistration.Id
                });
            }
        }
    }
}
