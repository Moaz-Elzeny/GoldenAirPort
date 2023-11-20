using GoldenAirport.Application.TripRegistrations.Dtos;

namespace GoldenAirport.Application.PackageRegistrations.Dtos
{
    public class PackageRegistrationByIdDto
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public decimal AdultCost { get; set; }
        public decimal? ChildCost { get; set; }
        //public decimal? AdminFees { get; set; }
        //public decimal? EmployeeFees { get; set; }
        public decimal? TaxesAndFees { get; set; }
        public int TotalAmount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<AdultTripRegistrationDto> Adults { get; set; }
        public List<ChildrenTripRegistrationDto> Children { get; set; }
    }
}
