using GoldenAirport.Application.TripRegistrations.Dtos;

namespace GoldenAirport.Application.PackageRegistrations.Dtos
{
    public class EditPackageRegistrationDto
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<AdultDto> Adult { get; set; }
        public List<ChildDto> Child { get; set; }
    }
}
