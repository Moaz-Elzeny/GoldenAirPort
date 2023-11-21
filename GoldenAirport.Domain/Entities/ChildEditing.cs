namespace GoldenAirport.Domain.Entities
{
    public class ChildEditing : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PassportNo { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int? TripRegistrationEditingId { get; set; }
        public virtual TripRegistrationEditing TripRegistrationEditing { get; set; }
        public int? PackageRegistrationEditingId { get; set; }
        public virtual PackageRegistrationEditing PackageRegistrationEditing { get; set; }

    }
}
