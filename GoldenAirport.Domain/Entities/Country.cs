using GoldenAirport.Domain.Entities.Auth;

namespace GoldenAirport.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Country() 
        {
            Cities = new HashSet<City>();
            AppUsers = new HashSet<AppUser>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public short Code { get; set; }
        public string Icon { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
