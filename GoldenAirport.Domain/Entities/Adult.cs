using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Domain.Entities
{
    public class Adult : BaseEntity
    {
        public int Id { get; set; }
        public Title Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string? PassportNo { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int? TripRegistrationId { get; set;}
        public virtual TripRegistration TripRegistration { get; set; }
        public int? PackageRegistrationId { get; set;}
        public virtual PackageRegistration PackageRegistration { get; set; }
    }
}
