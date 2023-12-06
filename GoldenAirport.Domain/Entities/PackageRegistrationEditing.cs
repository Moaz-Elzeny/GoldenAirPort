namespace GoldenAirport.Domain.Entities
{
    public class PackageRegistrationEditing : BaseEntity
    {
        public PackageRegistrationEditing()
        {
            AdultsEditing = new HashSet<AdultEditing>();
            ChildrenEditing = new HashSet<ChildEditing>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public int PackageRegistrationId { get; set; }
        public virtual PackageRegistration PackageRegistration { get; set; }

        public virtual ICollection<AdultEditing> AdultsEditing { get; set; }
        public virtual ICollection<ChildEditing> ChildrenEditing { get; set; }
    }
}
