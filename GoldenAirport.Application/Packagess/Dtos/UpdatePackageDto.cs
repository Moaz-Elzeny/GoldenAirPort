using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Packagess.Dtos
{
    public class UpdatePackageDto
    {
        public string Name { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public decimal? AdultPrice { get; set; }
        public decimal? ChildPrice { get; set; }
        public int? FromCityId { get; set; }
        public int? ToCityId { get; set; }
        public string? AboutExploreTour { get; set; }
        public string? IsRefundable { get; set; }
    }
}
