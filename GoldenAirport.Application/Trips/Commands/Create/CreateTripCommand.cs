using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Trips.Commands.Create
{
    public class CreateTripCommand : IRequest<ResponseDto<object>>
    {
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        public byte Guests { get; set; }
        public string TripHours { get; set; }
        public int FromCityId { get; set; }
        public List<int> ToCitiesIds { get; set; }
        public List<string> WhyVisits { get; set; }
        public List<string> WhatAreIncluded { get; set; }
        public List<string> Accessibilitys { get; set; }
        public List<string> Restrictions { get; set; }
        //public List<int> PaymentOptions { get; set; }
        public string IsRefundable { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateTripHandler : IRequestHandler<CreateTripCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateTripHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
            {
                var trip = new Trip
                {
                    StartingDate = request.StartingDate,
                    EndingDate = request.EndingDate,
                    Price = request.AdultPrice,
                    ChildPrice = request.ChildPrice,
                    Guests = request.Guests,
                    RemainingGuests = 0,
                    TripHours = TimeSpan.Parse(request.TripHours),
                    FromCityId = request.FromCityId,
                    IsRefundable =bool.Parse(request.IsRefundable),
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

                var accessibilities = new List<Accessibility>();
                foreach (var accessibility in request.Accessibilitys)
                {
                    accessibilities.Add(new Accessibility
                    {
                        Description = accessibility,
                        TripId = trip.Id
                    });
                }

                _dbContext.Accessibilities.AddRange(accessibilities);
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

                //var paymentOptions = new List<PaymentOptionTrip>();
                //foreach (var Option in request.PaymentOptions)
                //{
                //    paymentOptions.Add(new PaymentOptionTrip
                //    {
                //        PaymentOptionId = Option,
                //        TripId = trip.Id
                //    });
                //}

                //_dbContext.PaymentOptionTrips.AddRange(paymentOptions);
                //await _dbContext.SaveChangesAsync(cancellationToken);

                var TripRegistration = new TripRegistration
                {
                    TripId = trip.Id,
                    //PackageCost = trip.Price + trip.ChildPrice,
                    
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully!",
                    Result = new
                    {
                        result = trip.Id
                    }
                });
            }
        }
    }
}
