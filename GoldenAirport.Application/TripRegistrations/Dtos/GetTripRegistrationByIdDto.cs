using GoldenAirport.Application.Trips.Dtos;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Dtos
{
    public class GetTripRegistrationByIdDto
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string TripHours { get; set; }
        public decimal AdultCost { get; set; }
        public decimal? ChildCost { get; set; }
        public decimal? AdminFees { get; set; }
        public decimal? EmployeeFees { get; set; }
        public decimal? Taxes { get; set; }
        public decimal TotalAmount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public GetFromCityDto FromCities { get; set; }
        public IEnumerable<GetCitiesDto> ToCities { get; set; }
        public List<AdultTripRegistrationDto> Adults { get; set; }
        public List<ChildrenTripRegistrationDto> Children { get; set; }

        public IEnumerable<object> WhyVisit { get; set; }
        public IEnumerable<object> WhatIsIncluded { get; set; }
        public IEnumerable<object> Restrictions { get; set; }
        public IEnumerable<object> Accessibility { get; set; }
    }

    public class AdultTripRegistrationDto
    {
        public Title Title { get; set; }
        public string TitleValue { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdultPassportNo { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class ChildrenTripRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdultPassportNo { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
