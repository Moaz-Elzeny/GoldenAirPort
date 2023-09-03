using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Packagess.Dtos
{
    public class GetPackagesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal Price { get; set; }
        public decimal PriceLessThan2YearsOld { get; set; }
        public decimal PriceLessThan12YearsOld { get; set; }
        public int CountryId { get; set; }
        public int FromCityId { get; set; }
        public string FromCityName { get; set; }
        public bool IsRefundable { get; set; }
        public paymentMethod PaymentOptions { get; set; }

        public IEnumerable<GetPackegeCitiesDto> ToCities { get; set; }
        public IEnumerable<object> PackagePlan { get; set; }

    }
}
