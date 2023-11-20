using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Enums;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.TripRegistrations.Commands.Edit
{
    public class EditTripRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }        
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public Title? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AdultPassportNo { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? ChildPassportNo { get; set; }
        public AgeRange? AgeRange { get; set; }
        public int? TripId { get; set; }
        public int? NoOfAdults { get; set; } = 1;
        public string? CurrentUserId { get; set; }

        public class EditTripRegistrationHandler : IRequestHandler<EditTripRegistrationCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditTripRegistrationHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditTripRegistrationCommand request, CancellationToken cancellationToken)
            {
                var user = _dbContext.AppUsers.AsQueryable();

                var tripRegistration = await _dbContext.TripRegistrations
                    .Include(a => a.Adults)
                    .Include(a => a.Children)
                    .FirstOrDefaultAsync(t => t.Id == request.Id) ?? throw new NotFoundException("Trip Registration not found.");

                if (request.CurrentUserId == user.Select(u => u.Id).FirstOrDefault())
                {
                    
                    tripRegistration.Email = request.Email ?? tripRegistration.Email;
                    tripRegistration.PhoneNumber = request.PhoneNumber ?? tripRegistration.PhoneNumber;

                    if (request.Title != null)
                    {
                        tripRegistration.Adults.FirstOrDefault(a => a.Title == request.Title);
                    }

                    if (request.FirstName != null)
                    {
                        tripRegistration.Adults.FirstOrDefault(a => a.FirstName == request.FirstName);
                    }

                    if (request.LastName != null)
                    {
                        tripRegistration.Adults.FirstOrDefault(a => a.LastName == request.LastName);
                    }

                    if (request.AdultPassportNo != null)
                    {
                        tripRegistration.Adults.FirstOrDefault(a => a.PassportNo == request.AdultPassportNo);
                    }

                    if (request.DateOfBirth != null)
                    {
                        tripRegistration.Adults.FirstOrDefault(a => a.DateOfBirth == request.DateOfBirth);
                    }


                    if (request.ChildPassportNo != null)
                    {
                        tripRegistration.Children.FirstOrDefault(a => a.PassportNo == request.ChildPassportNo);
                    }


                    if (request.TripId != null)
                    {
                        tripRegistration.TripId = request.TripId.Value;
                    }


                    request.NoOfAdults = request.NoOfAdults;

                    tripRegistration.ModifiedById = request.CurrentUserId;
                    tripRegistration.ModificationDate = DateTime.Now;

                   

                }

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully!",
                    Result = new
                    {
                        result = tripRegistration.Id
                    }
                });
            }
        }
    }
}
