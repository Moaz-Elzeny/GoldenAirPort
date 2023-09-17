using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Packagess.Dtos
{
    public class UpdatePackageDto
    {
        public string Name { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? ChildPrice { get; set; }
        //public decimal? PriceLessThan12YearsOld { get; set; }
        public int? CountryId { get; set; }
        public int? FromCityId { get; set; }
        public List<int>? ToCitiesIds { get; set; }
        public bool? IsRefundable { get; set; }
        //public paymentMethod? PaymentMethod { get; set; }
    }
}
