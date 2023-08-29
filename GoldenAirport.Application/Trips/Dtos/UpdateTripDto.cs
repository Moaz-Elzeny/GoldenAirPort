using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Trips.Dtos
{
    public class UpdateTripDto
    {
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceLessThan2YearsOld { get; set; }
        public decimal? PriceLessThan12YearsOld { get; set; }
        public byte? Guests { get; set; }
        public string? TripHours { get; set; }
        public int? FromCityId { get; set; }
        public List<int>? ToCitiesIds { get; set; }
        public paymentMethod? PaymentMethod { get; set; }
        public bool? IsRefundable { get; set; }


    }
}
