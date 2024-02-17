namespace GoldenAirport.Application.Flights.ThirdParty.Dtos.Error
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AdditionalMessage
    {
        public string type { get; set; }
        public string errorCode { get; set; }
        public string message { get; set; }
    }

    public class ErrorDTO
    {
        public string status { get; set; }
        public DateTime timeStamp { get; set; }
        public Server server { get; set; }
        public string type { get; set; }
        public string errorCode { get; set; }
        public string message { get; set; }
        public List<AdditionalMessage> additionalMessages { get; set; }
    }

    public class Server
    {
        public string host { get; set; }
        public string port { get; set; }
    }


}
