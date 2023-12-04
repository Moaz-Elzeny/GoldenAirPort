using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Application.Trips.Dtos;

namespace GoldenAirport.Application.RegistrationsEditing.DTOs
{
    public class TripRegistrationEditingByIdDto
    {
        public int Id { get; set; }
        public int TripRegistrationId { get; set; }
        public decimal AdultCost { get; set; }
        public decimal? ChildCost { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string TripHours { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public GetFromCityDto FromCity { get; set; }
        public IEnumerable<GetCitiesDto> ToCities { get; set; }
        public List<AdultTripRegistrationDto> Adults { get; set; }
        public List<ChildrenTripRegistrationDto> Children { get; set; }
        public IEnumerable<object> WhyVisit { get; set; }
        public IEnumerable<object> WhatIsIncluded { get; set; }
        public IEnumerable<object> Restrictions { get; set; }
        public IEnumerable<object> Accessibility { get; set; }
    }
}
