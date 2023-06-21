namespace Etqaan.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Icon { get; set; }
    }
}
