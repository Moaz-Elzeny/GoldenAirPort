namespace GoldenAirport.Application.Flights.DTOs
{
    public class GetFlightDto
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string TakeOffDate { get; set; }
        public string DateOfArrival { get; set; }
        public string FlightHours { get; set;}
        public string FlightPrice { get; set;}
        public string FlightPriceLessThanTwoYears { get; set;}
        public string FlightPriceLessThanTwelveYears { get; set;}
        public string IsRefundable { get; set; }
        public string AirLine { get; set; }
        public string NumberOfSeats { get; set; }
        public string NumberOfBags { get; set; }
        public string TravelClass { get; set; }

    }
}
