using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Dtos
{
    public class GetTripRegistrationDto
    {
        public int Id { get; set; }
        public decimal PackageCost { get; set; }
        public decimal TaxesAndFees { get; set; }
        public decimal OtherFees { get; set; }
        public decimal TotalAmount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Title Title { get; set; }
        public string TitleValue { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdultPassportNo { get; set; }
        public DateTime DateOfBirth { get; set; }

        //public string? ChildPassportNo { get; set; }
        //public AgeRange? AgeRange { get; set; }
        //public int TripId { get; set; }
        //public int NoOfAdults { get; set; } = 1;
    }
}
