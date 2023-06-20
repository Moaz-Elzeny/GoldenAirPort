using Etqaan.Domain.Entities.Auth;

namespace Etqaan.Domain.Entities
{
    public class Nationality : BaseEntity2
    {
        public Nationality()
        {
            AppUsers = new HashSet<AppUser>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }

    }
}
