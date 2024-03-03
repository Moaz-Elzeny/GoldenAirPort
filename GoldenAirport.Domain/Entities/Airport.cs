namespace GoldenAirport.Domain.Entities
{
    public class Airport : BaseEntity
    {
        public Airport() { }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
    }
}
