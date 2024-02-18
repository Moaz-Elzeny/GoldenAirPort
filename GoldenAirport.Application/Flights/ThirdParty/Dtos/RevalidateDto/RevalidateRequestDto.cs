namespace GoldenAirport.Application.Flights.ThirdParty.Dtos.RevalidateDto
{
    //public class RevalidateRequestDto
    //{
    //}

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Airline
    {
        public string Operating { get; set; }
        public string Marketing { get; set; }
    }

    public class AirTravelerAvail
    {
        public List<PassengerTypeQuantity> PassengerTypeQuantity { get; set; }
    }

    public class CompanyName
    {
        public string Code { get; set; }
    }

    public class DestinationLocation
    {
        public string LocationCode { get; set; }
    }

    public class Flight
    {
        public int? Number { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public DateTime? ArrivalDateTime { get; set; }
        public string Type { get; set; }
        public string ClassOfService { get; set; }
        public DestinationLocation DestinationLocation { get; set; }
        public OriginLocation OriginLocation { get; set; }
        public Airline Airline { get; set; }
    }

    public class JumpCabinLogic
    {
        public bool? Disabled { get; set; }
    }

    public class KeepSameCabin
    {
        public bool? Enabled { get; set; }
    }

    public class OriginDestinationInformation
    {
        public string RPH { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public OriginLocation OriginLocation { get; set; }
        public DestinationLocation DestinationLocation { get; set; }
        public TPAExtensions TPA_Extensions { get; set; }
    }

    public class OriginLocation
    {
        public string LocationCode { get; set; }
    }

    public class OTAAirLowFareSearchRQ
    {
        public string Version { get; set; }
        public POS POS { get; set; }
        public List<OriginDestinationInformation> OriginDestinationInformation { get; set; }
        public TravelPreferences TravelPreferences { get; set; }
        public TravelerInfoSummary TravelerInfoSummary { get; set; }
    }

    public class PassengerTypeQuantity
    {
        public string Code { get; set; }
        public int? Quantity { get; set; }
        public TPAExtensions TPA_Extensions { get; set; }
    }

    public class POS
    {
        public List<Source> Source { get; set; }
    }

    public class PriceRequestInformation
    {
        public string CurrencyCode { get; set; }
        public TPAExtensions TPA_Extensions { get; set; }
    }

    public class RequestorID
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public CompanyName CompanyName { get; set; }
    }

    public class RevalidateRequestDto
    {
        public OTAAirLowFareSearchRQ OTA_AirLowFareSearchRQ { get; set; }
    }

    public class Source
    {
        public string PseudoCityCode { get; set; }
        public RequestorID RequestorID { get; set; }
    }

    public class TPAExtensions
    {
        public List<Flight> Flight { get; set; }
        public JumpCabinLogic JumpCabinLogic { get; set; }
        public KeepSameCabin KeepSameCabin { get; set; }
        public VerificationItinCallLogic VerificationItinCallLogic { get; set; }
        public VoluntaryChanges VoluntaryChanges { get; set; }
    }

    public class TravelerInfoSummary
    {
        public List<int?> SeatsRequested { get; set; }
        public List<AirTravelerAvail> AirTravelerAvail { get; set; }
        public PriceRequestInformation PriceRequestInformation { get; set; }
    }

    public class TravelPreferences
    {
        public TPAExtensions TPA_Extensions { get; set; }
    }

    public class VerificationItinCallLogic
    {
        public string Value { get; set; }
        public bool? AlwaysCheckAvailability { get; set; }
    }

    public class VoluntaryChanges
    {
        public string Match { get; set; }
    }


}
