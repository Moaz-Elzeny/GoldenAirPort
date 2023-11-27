namespace GoldenAirport.Application.Packagess.Dtos
{
    public class GetPackageByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        public string AboutExploreTour { get; set; }
        public bool IsRefundable { get; set; }
        public FromCityDto FromCity { get; set; }

        public GetPackegeCitiesDto ToCity { get; set; }
        public IEnumerable<PackagePlanDto> PackagePlan { get; set; }
    }

    public class PackagePlanDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
