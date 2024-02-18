namespace GoldenAirport.Application.Flights.ThirdParty.Dtos.RevalidateDto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class GroupedItineraryResponse
    {
        public string version { get; set; }
        public List<Message> messages { get; set; }
        public Statistics statistics { get; set; }
    }

    public class Message
    {
        public string severity { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string text { get; set; }
    }

    public class RevalidateResponseDto
    {
        public GroupedItineraryResponse groupedItineraryResponse { get; set; }
    }

    public class Statistics
    {
        public int? itineraryCount { get; set; }
    }


}
