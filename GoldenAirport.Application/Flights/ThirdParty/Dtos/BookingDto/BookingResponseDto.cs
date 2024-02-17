namespace GoldenAirport.Application.Flights.DTOs.BookingDto
{
    public class BookingResponseDto
    {
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Air
    {
        public int sequence { get; set; }
        public int segmentAssociationId { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalTerminalName { get; set; }
        public string ArrivalTerminalCode { get; set; }
        public string EquipmentType { get; set; }
        public string MarketingAirlineCode { get; set; }
        public string MarketingFlightNumber { get; set; }
        public string MarketingClassOfService { get; set; }
        public Cabin Cabin { get; set; }
        public List<string> MealCode { get; set; }
        public int ElapsedTime { get; set; }
        public int AirMilesFlown { get; set; }
        public bool FunnelFlight { get; set; }
        public bool ChangeOfGauge { get; set; }
        public DisclosureCarrier DisclosureCarrier { get; set; }
        public string AirlineRefId { get; set; }
        public bool Eticket { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string FlightNumber { get; set; }
        public string ClassOfService { get; set; }
        public string ActionCode { get; set; }
        public int NumberInParty { get; set; }
        public bool inboundConnection { get; set; }
        public bool outboundConnection { get; set; }
        public bool ScheduleChangeIndicator { get; set; }
        public DateTime SegmentBookedDate { get; set; }
    }

    public class AirBook
    {
        public OriginDestinationOption OriginDestinationOption { get; set; }
    }

    public class AirItineraryPricingInfo
    {
        public string SolutionSequenceNmbr { get; set; }
        public List<BaggageProvision> BaggageProvisions { get; set; }
        public FareCalculation FareCalculation { get; set; }
        public List<FareCalculationBreakdown> FareCalculationBreakdown { get; set; }
        public ItinTotalFare ItinTotalFare { get; set; }
        public PassengerTypeQuantity PassengerTypeQuantity { get; set; }
        public List<PTCFareBreakdown> PTC_FareBreakdown { get; set; }
    }

    public class Airline
    {
        public string Code { get; set; }
    }

    public class AirPrice
    {
        public PriceComparison PriceComparison { get; set; }
        public PriceQuote PriceQuote { get; set; }
    }

    public class AirSegment
    {
        public string CarrierCode { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureDate { get; set; }
        public string BoardPoint { get; set; }
        public string OffPoint { get; set; }
        public string ClassOfService { get; set; }
        public string BookingStatus { get; set; }
    }

    public class AncillaryService
    {
        public string SubGroupCode { get; set; }
        public string Text { get; set; }
    }

    public class ApplicationResults
    {
        public string status { get; set; }
        public List<Success> Success { get; set; }
        public List<Warning> Warning { get; set; }
    }

    public class Associations
    {
        public List<CarrierCode> CarrierCode { get; set; }
        public string CountForSegmentAssociatedID { get; set; }
        public List<DepartureDate> DepartureDate { get; set; }
        public List<DestinationLocation> DestinationLocation { get; set; }
        public List<FlightNumber> FlightNumber { get; set; }
        public List<OriginLocation> OriginLocation { get; set; }
        public List<PNRSegment> PNR_Segment { get; set; }
        public List<ResBookDesigCode> ResBookDesigCode { get; set; }
        public List<StatusCode> StatusCode { get; set; }
    }

    public class BaggageAllowance
    {
        public string Number { get; set; }
    }

    public class BaggageInfo
    {
        public List<SubCodeProperty> SubCodeProperties { get; set; }
        public NonUSDOTDisclosure NonUS_DOT_Disclosure { get; set; }
    }

    public class BaggageProvision
    {
        public string RPH { get; set; }
        public Associations Associations { get; set; }
        public string CarrierWhoseBaggageProvisionsApply { get; set; }
        public string NumPiecesBDI { get; set; }
        public List<string> NumPiecesITR { get; set; }
        public string ProvisionType { get; set; }
        public SubCodeInfo SubCodeInfo { get; set; }
        public string Commissionable { get; set; }
        public string FeeApplicationIndicator { get; set; }
        public string FeeNotGuaranteedIndicator { get; set; }
        public PassengerType PassengerType { get; set; }
        public PriceInformation PriceInformation { get; set; }
        public string RefundReissue { get; set; }
        public WeightLimit WeightLimit { get; set; }
    }

    public class Base
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class BaseFare
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class Branch
    {
        public string PCC { get; set; }
        public string FirstJointCarrier { get; set; }
    }

    public class Cabin
    {
        public string Code { get; set; }
        public string SabreCode { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Lang { get; set; }
        public string code { get; set; }
        public string sabreCode { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string lang { get; set; }
    }

    public class CarrierCode
    {
        public int RPH { get; set; }
        public string content { get; set; }
    }

    public class Construction
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string RateOfExchange { get; set; }
    }

    public class ContactNumber
    {
        public string LocationCode { get; set; }
        public string Phone { get; set; }
        public string RPH { get; set; }
        public string Id { get; set; }
    }

    public class ContactNumbers
    {
        public List<ContactNumber> ContactNumber { get; set; }
    }

    public class CreatePassengerNameRecordRS
    {
        public ApplicationResults ApplicationResults { get; set; }
        public ItineraryRef ItineraryRef { get; set; }
        public AirBook AirBook { get; set; }
        public List<AirPrice> AirPrice { get; set; }
        public TravelItineraryRead TravelItineraryRead { get; set; }
    }

    public class CustomerInfo
    {
        public ContactNumbers ContactNumbers { get; set; }
        public List<PersonName> PersonName { get; set; }
    }

    public class Dates
    {
        public string DepartureDateTime { get; set; }
        public string ArrivalDateTime { get; set; }
    }

    public class Departure
    {
        public string CityCode { get; set; }
        public string AirportCode { get; set; }
        public string AirlineCode { get; set; }
        public string GenericInd { get; set; }
        public string ArrivalCityCode { get; set; }
        public string ArrivalAirportCode { get; set; }
    }

    public class DepartureDate
    {
        public int RPH { get; set; }
        public string content { get; set; }
    }

    public class DescriptionOne
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }

    public class DescriptionTwo
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }

    public class DestinationLocation
    {
        public string LocationCode { get; set; }
        public int RPH { get; set; }
        public string Terminal { get; set; }
        public string TerminalCode { get; set; }
    }

    public class DisclosureCarrier
    {
        public string Code { get; set; }
        public bool DOT { get; set; }
        public string Banner { get; set; }
    }

    public class Email
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
        public string content { get; set; }
        public string comment { get; set; }
        public string type { get; set; }
        public string Address { get; set; }
    }

    public class Endorsement
    {
        public string type { get; set; }
        public string Text { get; set; }
    }

    public class Endorsements
    {
        public List<string> Text { get; set; }
        public List<Endorsement> Endorsement { get; set; }
    }

    public class Equipment
    {
        public string AirEquipType { get; set; }
    }

    public class Equiv
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class EquivFare
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class FareBasis
    {
        public string Code { get; set; }
        public string FareAmount { get; set; }
        public string FarePassengerType { get; set; }
        public string FareType { get; set; }
        public string FilingCarrier { get; set; }
        public string GlobalInd { get; set; }
        public string TripTypeInd { get; set; }
        public string Market { get; set; }
        public string Cabin { get; set; }
    }

    public class FareCalculation
    {
        public string Text { get; set; }
    }

    public class FareCalculationBreakdown
    {
        public Branch Branch { get; set; }
        public Departure Departure { get; set; }
        public FareBasis FareBasis { get; set; }
        public string FreeBaggageAllowance { get; set; }
        public List<string> RuleCategoryIndicator { get; set; }
    }

    public class FareComponent
    {
        public string FareBasisCode { get; set; }
        public string FareDirectionality { get; set; }
        public string Amount { get; set; }
        public string TicketDesignator { get; set; }
        public string GoverningCarrier { get; set; }
        public string FareComponentNumber { get; set; }
        public Location Location { get; set; }
        public Dates Dates { get; set; }
        public FlightSegmentNumbers FlightSegmentNumbers { get; set; }
    }

    public class FlightNumber
    {
        public int RPH { get; set; }
        public string content { get; set; }
    }

    public class FlightSegment
    {
        public string ArrivalDateTime { get; set; }
        public string DepartureDateTime { get; set; }
        public bool eTicket { get; set; }
        public string FlightNumber { get; set; }
        public string NumberInParty { get; set; }
        public string ResBookDesigCode { get; set; }
        public string Status { get; set; }
        public DestinationLocation DestinationLocation { get; set; }
        public MarketingAirline MarketingAirline { get; set; }
        public OriginLocation OriginLocation { get; set; }
        public string ConnectionInd { get; set; }
        public string SegmentNumber { get; set; }
        public BaggageAllowance BaggageAllowance { get; set; }
        public FareBasis FareBasis { get; set; }
        public ValidityDates ValidityDates { get; set; }
        public string AirMilesFlown { get; set; }
        public string DayOfWeekInd { get; set; }
        public DateTime SegmentBookedDate { get; set; }
        public string ElapsedTime { get; set; }
        public bool SmokingAllowed { get; set; }
        public bool SpecialMeal { get; set; }
        public string StopQuantity { get; set; }
        public bool IsPast { get; set; }
        public bool CodeShare { get; set; }
        public string Id { get; set; }
        public Equipment Equipment { get; set; }
        public List<Meal> Meal { get; set; }
        public List<OperatingAirline> OperatingAirline { get; set; }
        public OperatingAirlinePricing OperatingAirlinePricing { get; set; }
        public DisclosureCarrier DisclosureCarrier { get; set; }
        public SupplierRef SupplierRef { get; set; }
        public string UpdatedArrivalTime { get; set; }
        public string UpdatedDepartureTime { get; set; }
        public Cabin Cabin { get; set; }
    }

    public class FlightSegmentNumbers
    {
        public List<string> FlightSegmentNumber { get; set; }
    }

    public class HeaderInformation
    {
        public string SolutionSequenceNmbr { get; set; }
        public string DepartureDate { get; set; }
        public List<string> Text { get; set; }
        public ValidatingCarrier ValidatingCarrier { get; set; }
    }

    public class Item
    {
        public string RPH { get; set; }
        public List<FlightSegment> FlightSegment { get; set; }
        public Product Product { get; set; }
    }

    public class ItineraryInfo
    {
        public ItineraryPricing ItineraryPricing { get; set; }
        public ReservationItems ReservationItems { get; set; }
        public List<Ticketing> Ticketing { get; set; }
    }

    public class ItineraryPricing
    {
        public List<PriceQuote> PriceQuote { get; set; }
        public PriceQuoteTotals PriceQuoteTotals { get; set; }
    }

    public class ItineraryRef
    {
        public string ID { get; set; }
        public bool AirExtras { get; set; }
        public string InhibitCode { get; set; }
        public string PartitionID { get; set; }
        public string PrimeHostID { get; set; }
        public List<string> Header { get; set; }
        public Source Source { get; set; }
    }

    public class ItinTotalFare
    {
        public string NonRefundableInd { get; set; }
        public BaggageInfo BaggageInfo { get; set; }
        public BaseFare BaseFare { get; set; }
        public Construction Construction { get; set; }
        public Endorsements Endorsements { get; set; }
        public EquivFare EquivFare { get; set; }
        public Taxes Taxes { get; set; }
        public TotalFare TotalFare { get; set; }
        public Warnings Warnings { get; set; }
        public Totals Totals { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Location
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
    }

    public class MarketingAirline
    {
        public string Code { get; set; }
        public string FlightNumber { get; set; }
        public string ResBookDesigCode { get; set; }
        public string Banner { get; set; }
    }

    public class MaximumSize
    {
        public string Units { get; set; }
        public string content { get; set; }
    }

    public class MaximumSizeInAlternate
    {
        public string Units { get; set; }
        public string content { get; set; }
    }

    public class MaximumWeight
    {
        public string Units { get; set; }
        public string content { get; set; }
    }

    public class MaximumWeightInAlternate
    {
        public string Units { get; set; }
        public string content { get; set; }
    }

    public class Meal
    {
        public string Code { get; set; }
    }

    public class Message
    {
        public string code { get; set; }
        public string content { get; set; }
    }

    public class MiscInformation
    {
        public BaggageInfo BaggageInfo { get; set; }
        public List<HeaderInformation> HeaderInformation { get; set; }
        public List<SolutionInformation> SolutionInformation { get; set; }
        public List<ValidatingCarrier> ValidatingCarrier { get; set; }
        public List<SignatureLine> SignatureLine { get; set; }
    }

    public class NameAssociation
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int ReferenceId { get; set; }
        public string NameRefNumber { get; set; }
    }

    public class NonUSDOTDisclosure
    {
        public List<string> Text { get; set; }
    }

    public class OpenReservationElement
    {
        public string id { get; set; }
        public string type { get; set; }
        public string elementId { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public List<NameAssociation> NameAssociation { get; set; }
        public List<SegmentAssociation> SegmentAssociation { get; set; }
        public Email Email { get; set; }
    }

    public class OpenReservationElements
    {
        public List<OpenReservationElement> OpenReservationElement { get; set; }
    }

    public class OperatingAirline
    {
        public string Code { get; set; }
        public string FlightNumber { get; set; }
        public string ResBookDesigCode { get; set; }
        public string Banner { get; set; }
    }

    public class OperatingAirlinePricing
    {
        public string Code { get; set; }
    }

    public class OriginDestinationOption
    {
        public List<FlightSegment> FlightSegment { get; set; }
    }

    public class OriginLocation
    {
        public string LocationCode { get; set; }
        public int RPH { get; set; }
    }

    public class PassengerContactEmail
    {
        public string Email { get; set; }
        public string Language { get; set; }
    }

    public class PassengerContactMobilePhone
    {
        public string PhoneNumber { get; set; }
        public string Language { get; set; }
    }

    public class PassengerDatum
    {
        public string NameNumber { get; set; }
        public string content { get; set; }
    }

    public class PassengerInfo
    {
        public string PassengerType { get; set; }
        public List<PassengerDatum> PassengerData { get; set; }
    }

    public class PassengerType
    {
        public string Code { get; set; }
    }

    public class PassengerTypeQuantity
    {
        public string Code { get; set; }
        public string Quantity { get; set; }
    }

    public class PersonName
    {
        public string WithInfant { get; set; }
        public string NameNumber { get; set; }
        public string RPH { get; set; }
        public string elementId { get; set; }
        public List<Email> Email { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string content { get; set; }
    }

    public class PNRSegment
    {
        public int RPH { get; set; }
        public string content { get; set; }
    }

    public class PriceComparison
    {
        public string AmountReturned { get; set; }
        public string AmountSpecified { get; set; }
    }

    public class PricedItinerary
    {
        public string AlternativePricing { get; set; }
        public string CurrencyCode { get; set; }
        public bool MultiTicket { get; set; }
        public string TotalAmount { get; set; }
        public List<AirItineraryPricingInfo> AirItineraryPricingInfo { get; set; }
        public bool DisplayOnly { get; set; }
        public string InputMessage { get; set; }
        public string RPH { get; set; }
        public string StatusCode { get; set; }
        public bool TaxExempt { get; set; }
        public string ValidatingCarrier { get; set; }
        public string StoredDateTime { get; set; }
    }

    public class PriceInformation
    {
        public Base Base { get; set; }
        public Equiv Equiv { get; set; }
        public string Total { get; set; }
    }

    public class PriceQuote
    {
        public MiscInformation MiscInformation { get; set; }
        public PricedItinerary PricedItinerary { get; set; }
        public string RPH { get; set; }
        public ResponseHeader ResponseHeader { get; set; }
        public PriceQuotePlus PriceQuotePlus { get; set; }
    }

    public class PriceQuotePlus
    {
        public string DomesticIntlInd { get; set; }
        public string PricingStatus { get; set; }
        public bool VerifyFareCalc { get; set; }
        public bool ItineraryChanged { get; set; }
        public bool ManualFare { get; set; }
        public bool NegotiatedFare { get; set; }
        public string SystemIndicator { get; set; }
        public bool NUCSuppresion { get; set; }
        public bool SubjToGovtApproval { get; set; }
        public string IT_BT_Fare { get; set; }
        public bool DisplayOnly { get; set; }
        public string DiscountAmount { get; set; }
        public PassengerInfo PassengerInfo { get; set; }
        public TicketingInstructionsInfo TicketingInstructionsInfo { get; set; }
    }

    public class PriceQuoteTotals
    {
        public BaseFare BaseFare { get; set; }
        public EquivFare EquivFare { get; set; }
        public Taxes Taxes { get; set; }
        public TotalFare TotalFare { get; set; }
    }

    public class Product
    {
        public ProductDetails ProductDetails { get; set; }
    }

    public class ProductDetails
    {
        public string productCategory { get; set; }
        public ProductName ProductName { get; set; }
        public Air Air { get; set; }
    }

    public class ProductName
    {
        public string type { get; set; }
        public string content { get; set; }
    }

    public class PTCFareBreakdown
    {
        public string Cabin { get; set; }
        public FareBasis FareBasis { get; set; }
        public string FreeBaggageAllowance { get; set; }
        public Endorsements Endorsements { get; set; }
        public FareCalculation FareCalculation { get; set; }
        public string FareSource { get; set; }
        public List<FlightSegment> FlightSegment { get; set; }
        public List<FareComponent> FareComponent { get; set; }
    }

    public class ResBookDesigCode
    {
        public int RPH { get; set; }
        public string content { get; set; }
    }

    public class ReservationItems
    {
        public List<Item> Item { get; set; }
    }

    public class ResponseHeader
    {
        public List<string> Text { get; set; }
    }

    public class Root
    {
        public CreatePassengerNameRecordRS CreatePassengerNameRecordRS { get; set; }
        public List<Link> Links { get; set; }
    }

    public class SegmentAssociation
    {
        public string Id { get; set; }
        public string SegmentAssociationId { get; set; }
        public AirSegment AirSegment { get; set; }
    }

    public class Service
    {
        public string SSR_Code { get; set; }
        public string SSR_Type { get; set; }
        public Airline Airline { get; set; }
        public List<PersonName> PersonName { get; set; }
        public List<string> Text { get; set; }
    }

    public class ServiceRequest
    {
        public string actionCode { get; set; }
        public string airlineCode { get; set; }
        public string code { get; set; }
        public string serviceCount { get; set; }
        public string serviceType { get; set; }
        public string ssrType { get; set; }
        public string FreeText { get; set; }
        public string FullText { get; set; }
        public TravelDocument TravelDocument { get; set; }
        public PassengerContactMobilePhone PassengerContactMobilePhone { get; set; }
        public PassengerContactEmail PassengerContactEmail { get; set; }
        public string Comment { get; set; }
    }

    public class SignatureLine
    {
        public string ExpirationDateTime { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
    }

    public class SizeWeightInfo
    {
        public MaximumSizeInAlternate MaximumSizeInAlternate { get; set; }
        public MaximumSize MaximumSize { get; set; }
        public MaximumWeightInAlternate MaximumWeightInAlternate { get; set; }
        public MaximumWeight MaximumWeight { get; set; }
    }

    public class SolutionInformation
    {
        public string SolutionSequenceNmbr { get; set; }
        public string BaseFareCurrencyCode { get; set; }
        public string CurrencyCode { get; set; }
        public string GrandTotalBaseFareAmount { get; set; }
        public string GrandTotalEquivFareAmount { get; set; }
        public string GrandTotalTaxes { get; set; }
        public string RequiresRebook { get; set; }
        public string TicketNumber { get; set; }
        public string TotalAmount { get; set; }
    }

    public class Source
    {
        public string AAA_PseudoCityCode { get; set; }
        public string CreateDateTime { get; set; }
        public string CreationAgent { get; set; }
        public string HomePseudoCityCode { get; set; }
        public string PseudoCityCode { get; set; }
        public string ReceivedFrom { get; set; }
        public string LastUpdateDateTime { get; set; }
        public string SequenceNumber { get; set; }
    }

    public class SpecialServiceInfo
    {
        public string RPH { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public Service Service { get; set; }
    }

    public class StatusCode
    {
        public int RPH { get; set; }
        public string content { get; set; }
    }

    public class SubCodeForAllowance
    {
        public int RPH { get; set; }
        public string content { get; set; }
    }

    public class SubCodeInfo
    {
        public List<SubCodeForAllowance> SubCodeForAllowance { get; set; }
        public string SubCodeForChargesOthers { get; set; }
    }

    public class SubCodeProperty
    {
        public int SolutionSequenceNmbr { get; set; }
        public int RPH { get; set; }
        public string AncillaryFeeGroupCode { get; set; }
        public string CommercialNameofBaggageItemType { get; set; }
        public string EMD_Type { get; set; }
        public string ExtendedSubCodeKey { get; set; }
        public DescriptionOne DescriptionOne { get; set; }
        public DescriptionTwo DescriptionTwo { get; set; }
        public string RFIC { get; set; }
        public SizeWeightInfo SizeWeightInfo { get; set; }
        public string BookingMethod { get; set; }
        public string SSR_Code { get; set; }
        public AncillaryService AncillaryService { get; set; }
    }

    public class Success
    {
        public DateTime timeStamp { get; set; }
    }

    public class SupplierRef
    {
        public string ID { get; set; }
    }

    public class SystemSpecificResult
    {
        public List<Message> Message { get; set; }
    }

    public class Tax
    {
        public string Amount { get; set; }
        public string TaxCode { get; set; }
        public string TaxName { get; set; }
        public string TicketingTaxCode { get; set; }
    }

    public class TaxBreakdownCode
    {
        public bool TaxPaid { get; set; }
        public string content { get; set; }
    }

    public class Taxes
    {
        public string TotalAmount { get; set; }
        public List<Tax> Tax { get; set; }
        public List<TaxBreakdownCode> TaxBreakdownCode { get; set; }
    }

    public class Ticket
    {
        public string Type { get; set; }
        public string CarrierCode { get; set; }
        public string ValidatingCarrierType { get; set; }
    }

    public class Ticketing
    {
        public string RPH { get; set; }
        public string TicketTimeLimit { get; set; }
    }

    public class TicketingInstructionsInfo
    {
    }

    public class TotalFare
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class Totals
    {
        public BaseFare BaseFare { get; set; }
        public EquivFare EquivFare { get; set; }
        public Taxes Taxes { get; set; }
        public TotalFare TotalFare { get; set; }
    }

    public class TravelDocument
    {
        public string Type { get; set; }
        public string DocumentIssueCountry { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentNationalityCountry { get; set; }
        public string DocumentExpirationDate { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool Infant { get; set; }
        public bool PrimaryDocHolderInd { get; set; }
        public bool HasDocumentData { get; set; }
    }

    public class TravelItinerary
    {
        public CustomerInfo CustomerInfo { get; set; }
        public ItineraryInfo ItineraryInfo { get; set; }
        public ItineraryRef ItineraryRef { get; set; }
        public List<SpecialServiceInfo> SpecialServiceInfo { get; set; }
        public OpenReservationElements OpenReservationElements { get; set; }
    }

    public class TravelItineraryRead
    {
        public TravelItinerary TravelItinerary { get; set; }
    }

    public class ValidatingCarrier
    {
        public string Code { get; set; }
        public bool NewValidatingProcess { get; set; }
        public string SolutionSequenceNmbr { get; set; }
        public string SettlementMethod { get; set; }
        public List<Ticket> Ticket { get; set; }
    }

    public class ValidityDates
    {
        public string NotValidAfter { get; set; }
        public string NotValidBefore { get; set; }
    }

    public class Warning
    {
        public string type { get; set; }
        public DateTime timeStamp { get; set; }
        public List<SystemSpecificResult> SystemSpecificResults { get; set; }
        public string ShortText { get; set; }
    }

    public class Warnings
    {
        public List<Warning> Warning { get; set; }
    }

    public class WeightLimit
    {
        public string Units { get; set; }
        public string content { get; set; }
    }


}
