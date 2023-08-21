using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Trips.Commands.Create
{
    public class CreateTripCommand : IRequest<ResultDto<string>>
    {
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal Price { get; set; }
        public byte Guests { get; set; }
        public string TripHours { get; set; }
        public int FromCityId { get; set; }
        public List<int> ToCitiesIds { get; set; }
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
                    Guests = request.Guests,
                    TripHours = TimeSpan.Parse(request.TripHours),
                    FromCityId = request.FromCityId,
                    IsRefundable = true,
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

                return ResultDto<string>.Success("Trip Created Successfully!");
            }
        }
    }
}
