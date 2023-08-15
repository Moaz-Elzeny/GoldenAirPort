namespace GoldenAirport.Domain.Entities
{
    public class TripRegistration : BaseEntity
    {
        public TripRegistration() 
        {
            Adults = new HashSet<Adult>();
            Children = new HashSet<Child>();
        }
        public int Id { get; set; }
        public decimal PackageCost { get; set; }
        public decimal TaxesAdndFees { get; set; }
        public decimal OutherFees { get; set; }
        public decimal TotalAmount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        public virtual ICollection<Adult> Adults { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
}
