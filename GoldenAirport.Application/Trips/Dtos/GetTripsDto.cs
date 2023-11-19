using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Trips.Dtos
{
    public class GetTripsDto
    {
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        //public byte Guests { get; set; }
        //public byte RemainingGuests { get; set; }
        public string TripHours { get; set; }
        public bool IsRefundable { get; set; }

        public IEnumerable<GetCitiesDto> Cities { get; set; }
    //    public IEnumerable<object> PaymentOptions { get; set; }
    //    public IEnumerable<object> WhyVisit { get; set; }
    //    public IEnumerable<object> WhatIsIncluded { get; set; }
    //    public IEnumerable<object> Restrictions { get; set; }
    //    public IEnumerable<object> Accessibility { get; set; }
    }
}
