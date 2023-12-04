using GoldenAirport.Application.PackageRegistrations.Dtos;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Application.Trips.Dtos;

namespace GoldenAirport.Application.RegistrationsEditing.DTOs
{
    public class PackageRegistrationEditingByIdDto
    {
        public int Id { get; set; }
        public int PackageRegistrationId { get; set; }
        public string PackageName { get; set; }
        public decimal AdultCost { get; set; }
        public decimal? ChildCost { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int Day { get; set; }
        public int Night { get; set; }
        public decimal? TaxesAndFees { get; set; }
        public int TotalAmount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AboutExploreTour { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public GetFromCityDto FromCity { get; set; }
        public GetCitiesDto ToCity { get; set; }
        public List<AdultTripRegistrationDto> Adults { get; set; }
        public List<ChildrenTripRegistrationDto> Children { get; set; }
        public List<PackagePlanDto> PackagePlans { get; set; }
    }
}
