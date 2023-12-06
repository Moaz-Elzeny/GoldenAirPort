namespace GoldenAirport.Domain.Entities
{
    public class PackageRegistrationDeleting : BaseEntity2
    {
        public int Id { get; set; }
        public int PackageRegistrationId { get; set; }
        public virtual PackageRegistration PackageRegistration { get; set; }
    }
}
