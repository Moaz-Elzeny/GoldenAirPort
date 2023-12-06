namespace GoldenAirport.Domain.Entities
{
    public class TripRegistrationEditing : BaseEntity
    {
        public TripRegistrationEditing()
        {
            AdultsEditing = new HashSet<AdultEditing>();
            ChildrenEditing = new HashSet<ChildEditing>();
        }
        public int Id { get; set; }        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TripRegistrationId { get; set; }
        public virtual TripRegistration TripRegistration { get; set; }

        public virtual ICollection<AdultEditing> AdultsEditing { get; set; }
        public virtual ICollection<ChildEditing> ChildrenEditing { get; set; }
    }
}
