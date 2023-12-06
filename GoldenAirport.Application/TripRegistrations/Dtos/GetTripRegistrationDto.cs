using GoldenAirport.Application.Trips.Dtos;

namespace GoldenAirport.Application.TripRegistrations.Dtos
{
    public class GetTripRegistrationDto
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string TripHours { get; set; }
        public bool IsRefundable { get; set; }
        public bool RegistrationDeleteing { get; set; }
        public decimal TotalAmount { get; set; }
        public GetFromCityDto FromCities { get; set; }
        public IEnumerable<GetCitiesDto> ToCities { get; set; }
    }
    
}
