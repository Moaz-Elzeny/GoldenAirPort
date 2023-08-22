namespace GoldenAirport.Application.Trips.Dtos
{
    public class UpdateTripDto
    {
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public decimal? Price { get; set; }
        public byte? Guests { get; set; }
        public string? TripHours { get; set; }
        public int? FromCityId { get; set; }
        public List<int>? ToCitiesIds { get; set; }
        
    }
}
