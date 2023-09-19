using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.TripRegistrations.Commands.Create
{
    public class CreateTripRegistrationCommand : IRequest<ResultDto<object>>
    {
        public decimal PackageCost { get; set; }
        public decimal TaxesAndFees { get; set; }
        public decimal OtherFees { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Title Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? AdultPassportNo { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string? ChildPassportNo { get; set; }
        public int TripId { get; set; }
        public List<int> NoOfAdults { get; set; } ;
        //public int NoOfChildren { get; set; } = 1;
        public string? CurrentUserId { get; set; }

        public class CreateTripRegistrationHandler : IRequestHandler<CreateTripRegistrationCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateTripRegistrationHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(CreateTripRegistrationCommand request, CancellationToken cancellationToken)
            {
                var totalAmount = (request.PackageCost * request.NoOfAdults.Count) + request.TaxesAndFees + request.OtherFees;

                var tripRegistration = new TripRegistration
                {
                    PackageCost = request.PackageCost,
                    TaxesAndFees = request.TaxesAndFees,
                    OutherFees = request.OtherFees,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    TripId = request.TripId,
                    TotalAmount = totalAmount,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,

                };

                _dbContext.TripRegistrations.Add(tripRegistration);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var adult = new Adult
                {
                    TripRegistrationId = tripRegistration.Id,
                    Title = request.Title,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PassportNo = request.AdultPassportNo,
                    DateOfBirth = DateTime.Now,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                };


                var adults = new List<Adult>();
                foreach (var adultId in request.NoOfAdults)
                {
                    var city = await _dbContext.Adults.FindAsync(adultId, cancellationToken) ?? throw new NotFoundException("Adult not found.");

                    cityTrip.Add(new CityTrip
                    {
                        CityId = cityIds,
                        TripId = trip.Id,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now

                    });
                }

                _dbContext.Adults.Add(adult);
                await _dbContext.SaveChangesAsync(cancellationToken);

                //var child = new Child
                //{
                //    TripRegistrationId = tripRegistration.Id,
                //    PassportNo = request.ChildPassportNo,
                //    AgeRange = request.AgeRange
                //};

                //_dbContext.children.Add(child);
                //await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<object>.Success(tripRegistration.Id ,"Trip Registration Created Successfully!");
            }
        }
    }
}
