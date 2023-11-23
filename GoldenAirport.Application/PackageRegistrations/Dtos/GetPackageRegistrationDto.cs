using GoldenAirport.Application.Packagess.Dtos;

namespace GoldenAirport.Application.PackageRegistrations.Dtos
{
    public class GetPackageRegistrationDto
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int Day { get; set; }
        public int Night { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        public bool IsRefundable { get; set; }
        public decimal? ServiceFees { get; set; }

        public FromCityDto FromCity { get; set; }

        public GetPackegeCitiesDto ToCity { get; set; }

    }


}
