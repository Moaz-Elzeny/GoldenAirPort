namespace GoldenAirport.Domain.Entities
{
    public class PackagePlan
    {
        public PackagePlan() { }
        public int Id { get; set; }
        public string Description { get; set; }

        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}
