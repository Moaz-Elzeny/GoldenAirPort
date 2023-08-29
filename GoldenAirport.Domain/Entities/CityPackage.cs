namespace GoldenAirport.Domain.Entities
{
    public class CityPackage : BaseEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int PackageId { get; set; }
        public virtual City City { get; set; }
        public virtual Package Package { get; set; }
    }
}
