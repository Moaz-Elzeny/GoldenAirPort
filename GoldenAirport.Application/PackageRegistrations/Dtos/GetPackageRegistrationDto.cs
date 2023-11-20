namespace GoldenAirport.Application.PackageRegistrations.Dtos
{
    public class GetPackageRegistrationDto
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        public bool IsRefundable { get; set; }
        public decimal? ServiceFees { get; set; }

        public int FromCityId { get; set; }
        public string FromCityName { get; set; }
        public int? ToCityId { get; set; }
        public string ToCityName { get; set; }

        //public List<PackagePlanDto> PackagePlans { get; set; }
    }
    public class PackagePlanDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }


}
