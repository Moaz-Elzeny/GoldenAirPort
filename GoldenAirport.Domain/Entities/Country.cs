namespace GoldenAirport.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Country() 
        {
            Cities = new HashSet<City>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public byte Code { get; set; }
        public string Icon { get; set; }
        public ICollection<City> Cities { get; set; }
        //public ICollection<Package> packages { get; set; }
    }
}
