using System.ComponentModel;

namespace GoldenAirport.Application.Flights.DTOs
{
    public enum FlightTypeDto
    {
        [Description("ذهاب فقط")]
        OneWay = 1,
        [Description("ذهاب وعوده")]
        Return = 2,
        [Description("مدن متعددة")]
        MultiCities = 3,
    }
}
