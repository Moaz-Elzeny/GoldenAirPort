using System.Text.Json;

namespace GoldenAirport.Common
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<DetailsResponse> details { get; set; }

        public string ConvertToJson()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Serialize(this, options);
        }
    }
    public class DetailsResponse
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
