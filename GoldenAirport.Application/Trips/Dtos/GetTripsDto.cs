using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Trips.Dtos
{
    public class GetTripsDto
    {
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal Price { get; set; }
        public decimal PriceLessThan2YearsOld { get; set; }
        public decimal PriceLessThan12YearsOld { get; set; }
        public byte Guests { get; set; }
        public string TripHours { get; set; }
        public bool IsRefundable { get; set; }
        public paymentMethod PaymentOptions { get; set; }
        public GetFromCityDto FromCity { get; set; }

        public IEnumerable<GetCitiesDto> ToCities { get; set; }
        public IEnumerable<object> WhyVisit { get; set; }
        public IEnumerable<object> WhatIsIncluded { get; set; }
        public IEnumerable<object> Restrictions { get; set; }
        public IEnumerable<object> Accessibility { get; set; }
    }
}
