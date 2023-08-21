namespace GoldenAirport.Application.Trips.Dtos
{
    public class GetTripsDto
    {
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal Price { get; set; }
        public byte Guests { get; set; }
        public string TripHours { get; set; }
        public int FromCityId { get; set; }
        public string FromCityName { get; set; }
        public IEnumerable<GetCitiesDto> ToCities { get; set; }
    }
}
