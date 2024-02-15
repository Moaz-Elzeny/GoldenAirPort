namespace GoldenAirport.Application.Flights.DTOs.BookingDto
{
    public class RequestDto
    {
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AcceptablePriceIncrease
    {
        public bool HaltOnNonAcceptablePrice { get; set; }
        public int Amount { get; set; }
    }

    public class Address
    {
        public string AddressLine { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public StateCountyProv StateCountyProv { get; set; }
        public string StreetNmbr { get; set; }
    }

    public class AdvancePassenger
    {
        public string SegmentNumber { get; set; }
        public Document Document { get; set; }
        public PersonName PersonName { get; set; }
    }

    public class AgencyInfo
    {
        public Address Address { get; set; }
        public Ticketing Ticketing { get; set; }
    }

    public class AirBook
    {
        public List<HaltOnStatus> HaltOnStatus { get; set; }
        public RedisplayReservation RedisplayReservation { get; set; }
        public RetryRebook RetryRebook { get; set; }
        public OriginDestinationInformation OriginDestinationInformation { get; set; }
    }

    public class Airline
    {
        public string Code { get; set; }
    }

    public class AirPrice
    {
        public PriceComparison PriceComparison { get; set; }
        public PriceRequestInformation PriceRequestInformation { get; set; }
    }

    public class ARUNK
    {
        public bool priorPricing { get; set; }
    }

    public class ContactNumber
    {
        public string NameNumber { get; set; }
        public string Phone { get; set; }
        public string PhoneUseType { get; set; }
    }

    public class ContactNumbers
    {
        public List<ContactNumber> ContactNumber { get; set; }
    }

    public class CreatePassengerNameRecordRQ
    {
        public bool haltOnAirPriceError { get; set; }
        public string targetCity { get; set; }
        public AirBook AirBook { get; set; }
        public List<AirPrice> AirPrice { get; set; }
        public TravelItineraryAddInfo TravelItineraryAddInfo { get; set; }
        public SpecialReqDetails SpecialReqDetails { get; set; }
        public PostProcessing PostProcessing { get; set; }
    }

    public class CustomerInfo
    {
        public ContactNumbers ContactNumbers { get; set; }
        public List<Email> Email { get; set; }
        public List<PersonName> PersonName { get; set; }
    }

    public class DestinationLocation
    {
        public string LocationCode { get; set; }
    }

    public class Document
    {
        public string ExpirationDate { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string IssueCountry { get; set; }
        public string NationalityCountry { get; set; }
    }

    public class Email
    {
        public string NameNumber { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }

    public class EndTransaction
    {
        public Source Source { get; set; }
    }

    public class FlightSegment
    {
        public string DepartureDateTime { get; set; }
        public string FlightNumber { get; set; }
        public string NumberInParty { get; set; }
        public string ResBookDesigCode { get; set; }
        public string Status { get; set; }
        public DestinationLocation DestinationLocation { get; set; }
        public MarketingAirline MarketingAirline { get; set; }
        public OriginLocation OriginLocation { get; set; }
    }

    public class HaltOnStatus
    {
        public string Code { get; set; }
    }

    public class MarketingAirline
    {
        public string Code { get; set; }
        public string FlightNumber { get; set; }
    }

    public class OptionalQualifiers
    {
        public PricingQualifiers PricingQualifiers { get; set; }
    }

    public class OriginDestinationInformation
    {
        public List<FlightSegment> FlightSegment { get; set; }
    }

    public class OriginLocation
    {
        public string LocationCode { get; set; }
    }

    public class PassengerType
    {
        public string Code { get; set; }
        public string Quantity { get; set; }
    }

    public class PersonName
    {
        public string NameNumber { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string PassengerType { get; set; }
        public bool? Infant { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class PostBookingHKValidation
    {
        public int waitInterval { get; set; }
        public int numAttempts { get; set; }
    }

    public class PostProcessing
    {
        public RedisplayReservation RedisplayReservation { get; set; }
        public ARUNK ARUNK { get; set; }
        public EndTransaction EndTransaction { get; set; }
        public PostBookingHKValidation PostBookingHKValidation { get; set; }
        public WaitForAirlineRecLoc WaitForAirlineRecLoc { get; set; }
    }

    public class PriceComparison
    {
        public double AmountSpecified { get; set; }
        public AcceptablePriceIncrease AcceptablePriceIncrease { get; set; }
    }

    public class PriceRequestInformation
    {
        public bool Retain { get; set; }
        public OptionalQualifiers OptionalQualifiers { get; set; }
    }

    public class PricingQualifiers
    {
        public List<PassengerType> PassengerType { get; set; }
    }

    public class RedisplayReservation
    {
        public int NumAttempts { get; set; }
        public int WaitInterval { get; set; }
        public int waitInterval { get; set; }
    }

    public class RetryRebook
    {
        public bool Option { get; set; }
    }

    public class Root
    {
        public CreatePassengerNameRecordRQ CreatePassengerNameRecordRQ { get; set; }
    }

    public class SecureFlight
    {
        public string SegmentNumber { get; set; }
        public PersonName PersonName { get; set; }
    }

    public class Service
    {
        public string SSR_Code { get; set; }
        public PersonName PersonName { get; set; }
        public string Text { get; set; }
        public VendorPrefs VendorPrefs { get; set; }
        public string SegmentNumber { get; set; }
    }

    public class Source
    {
        public string ReceivedFrom { get; set; }
    }

    public class SpecialReqDetails
    {
        public SpecialService SpecialService { get; set; }
    }

    public class SpecialService
    {
        public SpecialServiceInfo SpecialServiceInfo { get; set; }
    }

    public class SpecialServiceInfo
    {
        public List<AdvancePassenger> AdvancePassenger { get; set; }
        public List<SecureFlight> SecureFlight { get; set; }
        public List<Service> Service { get; set; }
    }

    public class StateCountyProv
    {
        public string StateCode { get; set; }
    }

    public class Ticketing
    {
        public string TicketType { get; set; }
    }

    public class TravelItineraryAddInfo
    {
        public AgencyInfo AgencyInfo { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
    }

    public class VendorPrefs
    {
        public Airline Airline { get; set; }
    }

    public class WaitForAirlineRecLoc
    {
        public int waitInterval { get; set; }
        public int numAttempts { get; set; }
    }


}
