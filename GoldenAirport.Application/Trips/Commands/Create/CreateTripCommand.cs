using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Trips.Commands.Create
{
    public class CreateTripCommand : IRequest<ResultDto<string>>
    {
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal Price { get; set; }
        public decimal PriceLessThan2YearsOld { get; set; }
        public decimal PriceLessThan12YearsOld { get; set; }
        public byte Guests { get; set; }
        public string TripHours { get; set; }
        public int FromCityId { get; set; }
        public List<int> ToCitiesIds { get; set; }
        public List<string> WhyVisits { get; set; }
        public List<string> WhatAreIncluded { get; set; }
        public List<string> Accessibilitys { get; set; }
        public List<string> Restrictions { get; set; }
        public bool IsRefundable { get; set; }
        public paymentMethod PaymentMethod { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateTripHandler : IRequestHandler<CreateTripCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateTripHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
            {
                var trip = new Trip
                {
                    StartingDate = request.StartingDate,
                    EndingDate = request.EndingDate,
                    Price = request.Price,
                    PriceLessThan2YearsOld = request.PriceLessThan2YearsOld,
                    PriceLessThan12YearsOld = request.PriceLessThan12YearsOld,
                    Guests = request.Guests,
                    TripHours = TimeSpan.Parse(request.TripHours),
                    FromCityId = request.FromCityId,
                    IsRefundable = request.IsRefundable,
                    PaymentMethod = request.PaymentMethod,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,

                };

                _dbContext.Trips.Add(trip);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var cityTrip = new List<CityTrip>();
                foreach (var cityIds in request.ToCitiesIds)
                {
                    var city = await _dbContext.Cities.FindAsync(cityIds, cancellationToken) ?? throw new NotFoundException("City not found.");

                    cityTrip.Add( new CityTrip
                    {
                        CityId = cityIds,
                        TripId = trip.Id,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now

                    });
                }

                await _dbContext.CityTrips.AddRangeAsync(cityTrip, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var whyVisit = new List<WhyVisit>();
                foreach (var description in request.WhyVisits)
                {
                    whyVisit.Add(new WhyVisit
                    {
                        Description = description,
                        TripId = trip.Id
                    });
                }

                _dbContext.WhyVisits.AddRange(whyVisit);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var included = new List<WhatIsIncluded>();
                foreach (var includedDescription in request.WhatAreIncluded)
                {
                    included.Add(new WhatIsIncluded
                    {
                        Description = includedDescription,
                        TripId = trip.Id
                    });
                }

                _dbContext.WhatAreIncluded.AddRange(included);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var accessibilitys = new List<Accessibility>();
                foreach (var accessibility in request.Accessibilitys)
                {
                    accessibilitys.Add(new Accessibility
                    {
                        Description = accessibility,
                        TripId = trip.Id
                    });
                }

                _dbContext.Accessibilities.AddRange(accessibilitys);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var restrictions = new List<Restriction>();
                foreach (var description in request.Restrictions)
                {
                    restrictions.Add(new Restriction
                    {
                        Description = description,
                        TripId = trip.Id
                    });
                }

                _dbContext.Restrictions.AddRange(restrictions);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Trip Created Successfully!");
            }
        }
    }
}
