using Newtonsoft.Json;

namespace GoldenAirport.Application.Flights.ThirdParty.Dtos.ShopeDto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AirTravelerAvail
    {
        public List<PassengerTypeQuantity> PassengerTypeQuantity;
    }

    public class Baggage
    {
        public bool Description { get; set; }
        public string RequestType { get; set; }
    }

    public class CabinPref
    {
        public string Cabin { get; set; }
        public string PreferLevel { get; set; }
    }

    public class CompanyName
    {
        public string Code { get; set; }
    }

    public class CompressResponse
    {
        public bool Value { get; set; }
    }

    public class DataSources
    {
        public string NDC { get; set; }
        public string ATPCO { get; set; }
        public string LCC { get; set; }
    }

    public class DestinationLocation
    {
        public string LocationCode { get; set; }
    }

    public class ExcludeCallDirectCarriers
    {
        public bool Enabled { get; set; }
    }

    public class IntelliSellTransaction
    {
        public RequestType RequestType { get; set; }
        public CompressResponse CompressResponse { get; set; }
        public TravelerPersona TravelerPersona { get; set; }
    }

    public class KeepSameCabin
    {
        public bool Enabled { get; set; }
    }

    public class OriginDestinationInformation
    {
        public string RPH;
        public DateTime DepartureDateTime;
        public OriginLocation OriginLocation;
        public DestinationLocation DestinationLocation;
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
        public TPAExtensions2 TPA_Extensions { get; set; }
    }

    public class PassengerTypeQuantity
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
        public TPAExtensions1 TPA_Extensions { get; set; }
    }

    public class POS
    {
        public List<Source> Source { get; set; }
    }

    public class PreferNDCSourceOnTie
    {
        public bool Value { get; set; }
    }

    public class RequestorID
    {
        public string Type { get; set; }
        public string ID { get; set; }
        public CompanyName CompanyName { get; set; }
    }

    public class RequestType
    {
        public string Name { get; set; }
    }

    public class ShoppingRequestDto
    {
        public OTAAirLowFareSearchRQ OTA_AirLowFareSearchRQ = new OTAAirLowFareSearchRQ();
        public string ConvertToJson()
        {
            return JsonConvert.SerializeObject(this);
            //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        }
    }

    public class Source
    {
        public string PseudoCityCode { get; set; }
        public RequestorID RequestorID { get; set; }
    }

    public class TPAExtensions
    {
        public DataSources DataSources { get; set; }
        public PreferNDCSourceOnTie PreferNDCSourceOnTie { get; set; }
        public ExcludeCallDirectCarriers ExcludeCallDirectCarriers { get; set; }
        public KeepSameCabin KeepSameCabin { get; set; }
        //public VoluntaryChanges VoluntaryChanges { get; set; }
        //public IntelliSellTransaction IntelliSellTransaction { get; set; }
    }
    public class TPAExtensions1
    {
        //public DataSources DataSources { get; set; }
        //public PreferNDCSourceOnTie PreferNDCSourceOnTie { get; set; }
        //public ExcludeCallDirectCarriers ExcludeCallDirectCarriers { get; set; }
        //public KeepSameCabin KeepSameCabin { get; set; }
        public VoluntaryChanges VoluntaryChanges { get; set; }
        //public IntelliSellTransaction IntelliSellTransaction { get; set; }
    }
    public class TPAExtensions2
    {
        //public DataSources DataSources { get; set; }
        //public PreferNDCSourceOnTie PreferNDCSourceOnTie { get; set; }
        //public ExcludeCallDirectCarriers ExcludeCallDirectCarriers { get; set; }
        //public KeepSameCabin KeepSameCabin { get; set; }
        //public VoluntaryChanges VoluntaryChanges { get; set; }
        public IntelliSellTransaction IntelliSellTransaction { get; set; }
    }
    public class TravelerInfoSummary
    {
        public List<AirTravelerAvail> AirTravelerAvail { get; set; }
    }

    public class TravelerPersona
    {
        public string Name { get; set; }
    }

    public class TravelPreferences
    {
        public bool ValidInterlineTicket { get; set; }
        public TPAExtensions TPA_Extensions { get; set; }
        public Baggage Baggage { get; set; }
        public List<CabinPref> CabinPref { get; set; }
    }

    public class VoluntaryChanges
    {
        public string Match { get; set; }
    }


}
