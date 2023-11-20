using GoldenAirport.Domain.Entities.Auth;

namespace GoldenAirport.Domain.Entities
{
    public class PackageRegistration : BaseEntity
    {
        public PackageRegistration()
        {
            Adults = new HashSet<Adult>();
            Children = new HashSet<Child>();
        }
        public int Id { get; set; }
        public decimal AdultCost { get; set; }
        public decimal? ChildCost { get; set; }
        public decimal? AdminFees { get; set; }
        public decimal? EmployeeFees { get; set; }
        public decimal? Taxes { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int PackageId { get; set; }
        public virtual Package Package { get; set; }

        public string? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<Adult> Adults { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
}
