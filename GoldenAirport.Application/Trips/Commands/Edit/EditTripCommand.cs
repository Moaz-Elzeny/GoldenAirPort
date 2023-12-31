﻿using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Trips.Commands.Edit
{
    public class EditTripCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? ChildPrice { get; set; }
        public byte? Guests { get; set; }
        public string? TripHours { get; set; }
        public int? FromCityId { get; set; }
        public List<int>? ToCitiesIds { get; set; }
        public bool? IsRefundable { get; set; }
        public List<int>? PaymentOptions { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditTripHandler : IRequestHandler<EditTripCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditTripHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditTripCommand request, CancellationToken cancellationToken)
            {
                var trip = await _dbContext.Trips.FindAsync(request.Id) ?? throw new NotFoundException("Trip not found.");

                if (request.StartingDate != null)
                {
                    trip.StartingDate = request.StartingDate.Value;
                }

                if (request.EndingDate != null)
                {
                    trip.EndingDate = request.EndingDate.Value;
                }

                if (request.TripHours != null)
                {
                    trip.TripHours = TimeSpan.Parse(request.TripHours);
                }

                trip.Price = request.Price ?? trip.Price;
                trip.ChildPrice = request.ChildPrice ?? trip.ChildPrice;
                trip.Guests = request.Guests ?? trip.Guests;
                trip.FromCityId = request.FromCityId ?? trip.FromCityId;
                if (request.IsRefundable != null)
                {
                    trip.IsRefundable = request.IsRefundable.Value;
                }

                trip.ModifiedById = request.CurrentUserId;
                trip.ModificationDate = DateTime.Now;

                if (request.ToCitiesIds != null)
                {
                    var oldCities = _dbContext.CityTrips.Where(c => c.TripId == trip.Id);
                    _dbContext.CityTrips.RemoveRange(oldCities);

                    foreach (var ToCitiesId in request.ToCitiesIds)
                    {
                        var newCities = await _dbContext.Cities.FindAsync(ToCitiesId, cancellationToken) ?? throw new NotFoundException("City not found.");
                        if (newCities != null)
                        {
                            var addCities = new CityTrip
                            {
                                TripId = trip.Id,
                                CityId = ToCitiesId,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            };
                            _dbContext.CityTrips.Add(addCities);

                        }
                    }
                }

                //if (request.PaymentOptions != null)
                //{
                //    var oldPayments = _dbContext.PaymentOptionTrips.Where(c => c.TripId == trip.Id);
                //    _dbContext.PaymentOptionTrips.RemoveRange(oldPayments);

                //    var paymentOptions = new List<PaymentOptionTrip>();
                //    foreach (var Option in request.PaymentOptions)
                //    {
                //        paymentOptions.Add(new PaymentOptionTrip
                //        {
                //            PaymentOptionId = Option,
                //            TripId = trip.Id
                //        });
                //    }
                //    _dbContext.PaymentOptionTrips.AddRange(paymentOptions);
                //}

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully!",
                    Result = new
                    {
                        result = trip.Id
                    }
                });
            }
        }
    }
}
