
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldenAirport.Application.Flights.DTOs.BookingDto
{
  
   

    public partial class BookingResponseDto
    {
        [JsonProperty("CreatePassengerNameRecordRS")]
        public CreatePassengerNameRecordRs CreatePassengerNameRecordRs { get; set; }

        [JsonProperty("Links")]
        public List<Link> Links { get; set; }
    }

    public partial class CreatePassengerNameRecordRs
    {
        [JsonProperty("ApplicationResults")]
        public ApplicationResults ApplicationResults { get; set; }

        [JsonProperty("ItineraryRef")]
        public Ref ItineraryRef { get; set; }

        [JsonProperty("AirBook")]
        public AirBook AirBook { get; set; }

        [JsonProperty("AirPrice")]
        public List<AirPrice> AirPrice { get; set; }

        [JsonProperty("TravelItineraryRead")]
        public TravelItineraryRead TravelItineraryRead { get; set; }
    }

    public partial class AirBook
    {
        [JsonProperty("OriginDestinationOption")]
        public OriginDestinationOption OriginDestinationOption { get; set; }
    }

    public partial class OriginDestinationOption
    {
        [JsonProperty("FlightSegment")]
        public List<OriginDestinationOptionFlightSegment> FlightSegment { get; set; }
    }

    public partial class OriginDestinationOptionFlightSegment
    {
        [JsonProperty("ArrivalDateTime")]
        public string ArrivalDateTime { get; set; }

        [JsonProperty("DepartureDateTime")]
        public string DepartureDateTime { get; set; }

        [JsonProperty("eTicket")]
        public bool ETicket { get; set; }

        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("NumberInParty")]
        public string NumberInParty { get; set; }

        [JsonProperty("ResBookDesigCode")]
        public string ResBookDesigCode { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("DestinationLocation")]
        public FlightSegmentDestinationLocation DestinationLocation { get; set; }

        [JsonProperty("MarketingAirline")]
        public MarketingAirline MarketingAirline { get; set; }

        [JsonProperty("OriginLocation")]
        public FlightSegmentDestinationLocation OriginLocation { get; set; }
    }

    public partial class FlightSegmentDestinationLocation
    {
        [JsonProperty("LocationCode")]
        public string LocationCode { get; set; }
    }

    public partial class MarketingAirline
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; }
    }

    public partial class AirPrice
    {
        [JsonProperty("PriceComparison")]
        public PriceComparison PriceComparison { get; set; }

        [JsonProperty("PriceQuote")]
        public AirPricePriceQuote PriceQuote { get; set; }
    }

    public partial class PriceComparison
    {
        [JsonProperty("AmountReturned")]
        public string AmountReturned { get; set; }

        [JsonProperty("AmountSpecified")]
        public string AmountSpecified { get; set; }
    }

    public partial class AirPricePriceQuote
    {
        [JsonProperty("MiscInformation")]
        public PurpleMiscInformation MiscInformation { get; set; }

        [JsonProperty("PricedItinerary")]
        public PurplePricedItinerary PricedItinerary { get; set; }
    }

    public partial class PurpleMiscInformation
    {
        [JsonProperty("BaggageInfo")]
        public MiscInformationBaggageInfo BaggageInfo { get; set; }

        [JsonProperty("HeaderInformation")]
        public List<HeaderInformation> HeaderInformation { get; set; }

        [JsonProperty("SolutionInformation")]
        public List<SolutionInformation> SolutionInformation { get; set; }

        [JsonProperty("ValidatingCarrier")]
        public List<ValidatingCarrier> ValidatingCarrier { get; set; }
    }

    public partial class MiscInformationBaggageInfo
    {
        [JsonProperty("SubCodeProperties")]
        public List<SubCodeProperty> SubCodeProperties { get; set; }
    }

    public partial class SubCodeProperty
    {
        [JsonProperty("SolutionSequenceNmbr")]
        public long SolutionSequenceNmbr { get; set; }

        [JsonProperty("RPH")]
        public long Rph { get; set; }

        [JsonProperty("AncillaryFeeGroupCode")]
        public string AncillaryFeeGroupCode { get; set; }

        [JsonProperty("CommercialNameofBaggageItemType")]
        public string CommercialNameofBaggageItemType { get; set; }

        [JsonProperty("EMD_Type")]
        public string EmdType { get; set; }

        [JsonProperty("ExtendedSubCodeKey")]
        public string ExtendedSubCodeKey { get; set; }

        [JsonProperty("DescriptionOne", NullValueHandling = NullValueHandling.Ignore)]
        public Description DescriptionOne { get; set; }

        [JsonProperty("DescriptionTwo", NullValueHandling = NullValueHandling.Ignore)]
        public Description DescriptionTwo { get; set; }

        [JsonProperty("RFIC", NullValueHandling = NullValueHandling.Ignore)]
        public string Rfic { get; set; }

        [JsonProperty("SizeWeightInfo", NullValueHandling = NullValueHandling.Ignore)]
        public SizeWeightInfo SizeWeightInfo { get; set; }

        [JsonProperty("BookingMethod", NullValueHandling = NullValueHandling.Ignore)]
        public string BookingMethod { get; set; }

        [JsonProperty("SSR_Code", NullValueHandling = NullValueHandling.Ignore)]
        public string SsrCode { get; set; }

        [JsonProperty("AncillaryService", NullValueHandling = NullValueHandling.Ignore)]
        public AncillaryService AncillaryService { get; set; }
    }

    public partial class AncillaryService
    {
        [JsonProperty("SubGroupCode")]
        public string SubGroupCode { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    public partial class Description
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    public partial class SizeWeightInfo
    {
        [JsonProperty("MaximumSizeInAlternate")]
        public MaximumSize MaximumSizeInAlternate { get; set; }

        [JsonProperty("MaximumSize")]
        public MaximumSize MaximumSize { get; set; }

        [JsonProperty("MaximumWeightInAlternate")]
        public MaximumSize MaximumWeightInAlternate { get; set; }

        [JsonProperty("MaximumWeight")]
        public MaximumSize MaximumWeight { get; set; }
    }

    public partial class MaximumSize
    {
        [JsonProperty("Units")]
        public string Units { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class HeaderInformation
    {
        [JsonProperty("SolutionSequenceNmbr")]
        public string SolutionSequenceNmbr { get; set; }

        [JsonProperty("DepartureDate")]
        public string DepartureDate { get; set; }

        [JsonProperty("Text")]
        public List<string> Text { get; set; }

        [JsonProperty("ValidatingCarrier")]
        public Airline ValidatingCarrier { get; set; }
    }

    public partial class Airline
    {
        [JsonProperty("Code")]
        public string Code { get; set; }
    }

    public partial class SolutionInformation
    {
        [JsonProperty("SolutionSequenceNmbr")]
        public string SolutionSequenceNmbr { get; set; }

        [JsonProperty("BaseFareCurrencyCode")]
        public string BaseFareCurrencyCode { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("GrandTotalBaseFareAmount")]
        public string GrandTotalBaseFareAmount { get; set; }

        [JsonProperty("GrandTotalEquivFareAmount")]
        public string GrandTotalEquivFareAmount { get; set; }

        [JsonProperty("GrandTotalTaxes")]
        public string GrandTotalTaxes { get; set; }

        [JsonProperty("RequiresRebook")]
        public string RequiresRebook { get; set; }

        [JsonProperty("TicketNumber")]
        public string TicketNumber { get; set; }

        [JsonProperty("TotalAmount")]
        public string TotalAmount { get; set; }
    }

    public partial class ValidatingCarrier
    {
        [JsonProperty("NewValidatingProcess")]
        public bool NewValidatingProcess { get; set; }

        [JsonProperty("SolutionSequenceNmbr")]
        public string SolutionSequenceNmbr { get; set; }

        [JsonProperty("SettlementMethod")]
        public string SettlementMethod { get; set; }

        [JsonProperty("Ticket")]
        public List<Ticket> Ticket { get; set; }
    }

    public partial class Ticket
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("CarrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("ValidatingCarrierType")]
        public string ValidatingCarrierType { get; set; }
    }

    public partial class PurplePricedItinerary
    {
        [JsonProperty("AlternativePricing")]
        public string AlternativePricing { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("MultiTicket")]
        public bool MultiTicket { get; set; }

        [JsonProperty("TotalAmount")]
        public string TotalAmount { get; set; }

        [JsonProperty("AirItineraryPricingInfo")]
        public List<AirItineraryPricingInfoElement> AirItineraryPricingInfo { get; set; }
    }

    public partial class AirItineraryPricingInfoElement
    {
        [JsonProperty("SolutionSequenceNmbr")]
        public string SolutionSequenceNmbr { get; set; }

        [JsonProperty("BaggageProvisions")]
        public List<BaggageProvision> BaggageProvisions { get; set; }

        [JsonProperty("FareCalculation")]
        public FareCalculation FareCalculation { get; set; }

        [JsonProperty("FareCalculationBreakdown")]
        public List<FareCalculationBreakdown> FareCalculationBreakdown { get; set; }

        [JsonProperty("ItinTotalFare")]
        public PurpleItinTotalFare ItinTotalFare { get; set; }

        [JsonProperty("PassengerTypeQuantity")]
        public PassengerTypeQuantity PassengerTypeQuantity { get; set; }

        [JsonProperty("PTC_FareBreakdown")]
        public List<PurplePtcFareBreakdown> PtcFareBreakdown { get; set; }
    }

    public partial class BaggageProvision
    {
        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("Associations")]
        public Associations Associations { get; set; }

        [JsonProperty("CarrierWhoseBaggageProvisionsApply")]
        public string CarrierWhoseBaggageProvisionsApply { get; set; }

        [JsonProperty("NumPiecesBDI", NullValueHandling = NullValueHandling.Ignore)]
        public string NumPiecesBdi { get; set; }

        [JsonProperty("NumPiecesITR", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> NumPiecesItr { get; set; }

        [JsonProperty("ProvisionType")]
        public string ProvisionType { get; set; }

        [JsonProperty("SubCodeInfo")]
        public SubCodeInfo SubCodeInfo { get; set; }

        [JsonProperty("Commissionable", NullValueHandling = NullValueHandling.Ignore)]
        public string Commissionable { get; set; }

        [JsonProperty("FeeApplicationIndicator", NullValueHandling = NullValueHandling.Ignore)]
        public string FeeApplicationIndicator { get; set; }

        [JsonProperty("FeeNotGuaranteedIndicator", NullValueHandling = NullValueHandling.Ignore)]
        public string FeeNotGuaranteedIndicator { get; set; }

        [JsonProperty("PassengerType", NullValueHandling = NullValueHandling.Ignore)]
        public Airline PassengerType { get; set; }

        [JsonProperty("PriceInformation", NullValueHandling = NullValueHandling.Ignore)]
        public PriceInformation PriceInformation { get; set; }

        [JsonProperty("RefundReissue", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundReissue { get; set; }

        [JsonProperty("WeightLimit", NullValueHandling = NullValueHandling.Ignore)]
        public MaximumSize WeightLimit { get; set; }
    }

    public partial class Associations
    {
        [JsonProperty("CarrierCode")]
        public List<CarrierCode> CarrierCode { get; set; }

        [JsonProperty("CountForSegmentAssociatedID")]
        public string CountForSegmentAssociatedId { get; set; }

        [JsonProperty("DepartureDate")]
        public List<CarrierCode> DepartureDate { get; set; }

        [JsonProperty("DestinationLocation")]
        public List<DestinationLocationElement> DestinationLocation { get; set; }

        [JsonProperty("FlightNumber")]
        public List<CarrierCode> FlightNumber { get; set; }

        [JsonProperty("OriginLocation")]
        public List<DestinationLocationElement> OriginLocation { get; set; }

        [JsonProperty("PNR_Segment")]
        public List<CarrierCode> PnrSegment { get; set; }

        [JsonProperty("ResBookDesigCode")]
        public List<CarrierCode> ResBookDesigCode { get; set; }

        [JsonProperty("StatusCode")]
        public List<CarrierCode> StatusCode { get; set; }
    }

    public partial class CarrierCode
    {
        [JsonProperty("RPH")]
        public long Rph { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class DestinationLocationElement
    {
        [JsonProperty("LocationCode")]
        public string LocationCode { get; set; }

        [JsonProperty("RPH")]
        public long Rph { get; set; }
    }

    public partial class PriceInformation
    {
        [JsonProperty("Base")]
        public BaseClass Base { get; set; }

        [JsonProperty("Equiv")]
        public BaseClass Equiv { get; set; }

        [JsonProperty("Total")]
        public string Total { get; set; }
    }

    public partial class BaseClass
    {
        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }
    }

    public partial class SubCodeInfo
    {
        [JsonProperty("SubCodeForAllowance", NullValueHandling = NullValueHandling.Ignore)]
        public List<CarrierCode> SubCodeForAllowance { get; set; }

        [JsonProperty("SubCodeForChargesOthers")]
        public string SubCodeForChargesOthers { get; set; }
    }

    public partial class FareCalculation
    {
        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    public partial class FareCalculationBreakdown
    {
        [JsonProperty("Branch")]
        public Branch Branch { get; set; }

        [JsonProperty("Departure")]
        public Departure Departure { get; set; }

        [JsonProperty("FareBasis")]
        public FareCalculationBreakdownFareBasis FareBasis { get; set; }

        [JsonProperty("FreeBaggageAllowance")]
        public string FreeBaggageAllowance { get; set; }

        [JsonProperty("RuleCategoryIndicator")]
        public List<string> RuleCategoryIndicator { get; set; }
    }

    public partial class Branch
    {
        [JsonProperty("PCC")]
        public string Pcc { get; set; }

        [JsonProperty("FirstJointCarrier")]
        public string FirstJointCarrier { get; set; }
    }

    public partial class Departure
    {
        [JsonProperty("CityCode")]
        public string CityCode { get; set; }

        [JsonProperty("AirportCode")]
        public string AirportCode { get; set; }

        [JsonProperty("AirlineCode")]
        public string AirlineCode { get; set; }

        [JsonProperty("GenericInd")]
        public string GenericInd { get; set; }

        [JsonProperty("ArrivalCityCode")]
        public string ArrivalCityCode { get; set; }

        [JsonProperty("ArrivalAirportCode")]
        public string ArrivalAirportCode { get; set; }
    }

    public partial class FareCalculationBreakdownFareBasis
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("FareAmount")]
        public string FareAmount { get; set; }

        [JsonProperty("FarePassengerType")]
        public string FarePassengerType { get; set; }

        [JsonProperty("FareType")]
        public string FareType { get; set; }

        [JsonProperty("FilingCarrier")]
        public string FilingCarrier { get; set; }

        [JsonProperty("GlobalInd")]
        public string GlobalInd { get; set; }

        [JsonProperty("TripTypeInd")]
        public string TripTypeInd { get; set; }

        [JsonProperty("Market")]
        public string Market { get; set; }

        [JsonProperty("Cabin")]
        public string Cabin { get; set; }
    }

    public partial class PurpleItinTotalFare
    {
        [JsonProperty("NonRefundableInd")]
        public string NonRefundableInd { get; set; }

        [JsonProperty("BaggageInfo")]
        public ItinTotalFareBaggageInfo BaggageInfo { get; set; }

        [JsonProperty("BaseFare")]
        public BaseClass BaseFare { get; set; }

        [JsonProperty("Construction")]
        public Construction Construction { get; set; }

        [JsonProperty("Endorsements")]
        public ResponseHeader Endorsements { get; set; }

        [JsonProperty("EquivFare")]
        public BaseClass EquivFare { get; set; }

        [JsonProperty("Taxes")]
        public PurpleTaxes Taxes { get; set; }

        [JsonProperty("TotalFare")]
        public BaseClass TotalFare { get; set; }

        [JsonProperty("Warnings")]
        public Warnings Warnings { get; set; }
    }

    public partial class ItinTotalFareBaggageInfo
    {
        [JsonProperty("NonUS_DOT_Disclosure")]
        public ResponseHeader NonUsDotDisclosure { get; set; }
    }

    public partial class ResponseHeader
    {
        [JsonProperty("Text")]
        public List<string> Text { get; set; }
    }

    public partial class Construction
    {
        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("RateOfExchange")]
        public string RateOfExchange { get; set; }
    }

    public partial class PurpleTaxes
    {
        [JsonProperty("TotalAmount")]
        public string TotalAmount { get; set; }

        [JsonProperty("Tax")]
        public List<TaxElement> Tax { get; set; }
    }

    public partial class TaxElement
    {
        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("TaxCode")]
        public string TaxCode { get; set; }

        [JsonProperty("TaxName")]
        public string TaxName { get; set; }

        [JsonProperty("TicketingTaxCode")]
        public string TicketingTaxCode { get; set; }
    }

    public partial class Warnings
    {
        [JsonProperty("Warning")]
        public List<WarningsWarning> Warning { get; set; }
    }

    public partial class WarningsWarning
    {
        [JsonProperty("ShortText")]
        public string ShortText { get; set; }
    }

    public partial class PassengerTypeQuantity
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Quantity")]
        public string Quantity { get; set; }
    }

    public partial class PurplePtcFareBreakdown
    {
        [JsonProperty("Cabin")]
        public string Cabin { get; set; }

        [JsonProperty("FareBasis")]
        public PtcFareBreakdownFareBasis FareBasis { get; set; }

        [JsonProperty("FreeBaggageAllowance")]
        public string FreeBaggageAllowance { get; set; }
    }

    public partial class PtcFareBreakdownFareBasis
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("FareAmount")]
        public string FareAmount { get; set; }

        [JsonProperty("FarePassengerType")]
        public string FarePassengerType { get; set; }

        [JsonProperty("FareType")]
        public string FareType { get; set; }

        [JsonProperty("FilingCarrier")]
        public string FilingCarrier { get; set; }

        [JsonProperty("GlobalInd")]
        public string GlobalInd { get; set; }

        [JsonProperty("Market")]
        public string Market { get; set; }
    }

    public partial class ApplicationResults
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("Success")]
        public List<Success> Success { get; set; }

        [JsonProperty("Warning")]
        public List<ApplicationResultsWarning> Warning { get; set; }
    }

    public partial class Success
    {
        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }
    }

    public partial class ApplicationResultsWarning
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("SystemSpecificResults")]
        public List<SystemSpecificResult> SystemSpecificResults { get; set; }
    }

    public partial class SystemSpecificResult
    {
        [JsonProperty("Message")]
        public List<Message> Message { get; set; }
    }

    public partial class Message
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class Ref
    {
        [JsonProperty("ID")]
        public string Id { get; set; }
    }

    public partial class TravelItineraryRead
    {
        [JsonProperty("TravelItinerary")]
        public TravelItinerary TravelItinerary { get; set; }
    }

    public partial class TravelItinerary
    {
        [JsonProperty("CustomerInfo")]
        public CustomerInfo CustomerInfo { get; set; }

        [JsonProperty("ItineraryInfo")]
        public ItineraryInfo ItineraryInfo { get; set; }

        [JsonProperty("ItineraryRef")]
        public ItineraryRef ItineraryRef { get; set; }

        [JsonProperty("SpecialServiceInfo")]
        public List<SpecialServiceInfo> SpecialServiceInfo { get; set; }

        [JsonProperty("OpenReservationElements")]
        public OpenReservationElements OpenReservationElements { get; set; }
    }

    public partial class CustomerInfo
    {
        [JsonProperty("ContactNumbers")]
        public ContactNumbers ContactNumbers { get; set; }

        [JsonProperty("PersonName")]
        public List<PersonName> PersonName { get; set; }
    }

    public partial class ContactNumbers
    {
        [JsonProperty("ContactNumber")]
        public List<ContactNumber> ContactNumber { get; set; }
    }

    public partial class ContactNumber
    {
        [JsonProperty("LocationCode")]
        public string LocationCode { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public partial class PersonName
    {
        [JsonProperty("WithInfant")]
        public string WithInfant { get; set; }

        [JsonProperty("NameNumber")]
        public string NameNumber { get; set; }

        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("elementId")]
        public string ElementId { get; set; }

        [JsonProperty("Email")]
        public List<EmailElement> Email { get; set; }

        [JsonProperty("GivenName")]
        public string GivenName { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }
    }

    public partial class EmailElement
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Comment")]
        public string Comment { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class ItineraryInfo
    {
        [JsonProperty("ItineraryPricing")]
        public ItineraryPricing ItineraryPricing { get; set; }

        [JsonProperty("ReservationItems")]
        public ReservationItems ReservationItems { get; set; }

        [JsonProperty("Ticketing")]
        public List<Ticketing> Ticketing { get; set; }
    }

    public partial class ItineraryPricing
    {
        [JsonProperty("PriceQuote")]
        public List<PriceQuoteElement> PriceQuote { get; set; }

        [JsonProperty("PriceQuoteTotals")]
        public Totals PriceQuoteTotals { get; set; }
    }

    public partial class PriceQuoteElement
    {
        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("MiscInformation")]
        public FluffyMiscInformation MiscInformation { get; set; }

        [JsonProperty("PricedItinerary")]
        public List<PricedItineraryElement> PricedItinerary { get; set; }

        [JsonProperty("ResponseHeader")]
        public ResponseHeader ResponseHeader { get; set; }

        [JsonProperty("PriceQuotePlus")]
        public PriceQuotePlus PriceQuotePlus { get; set; }
    }

    public partial class FluffyMiscInformation
    {
        [JsonProperty("SignatureLine")]
        public List<SignatureLine> SignatureLine { get; set; }
    }

    public partial class SignatureLine
    {
        [JsonProperty("ExpirationDateTime")]
        public string ExpirationDateTime { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    public partial class PriceQuotePlus
    {
        [JsonProperty("DomesticIntlInd")]
        public string DomesticIntlInd { get; set; }

        [JsonProperty("PricingStatus")]
        public string PricingStatus { get; set; }

        [JsonProperty("VerifyFareCalc")]
        public bool VerifyFareCalc { get; set; }

        [JsonProperty("ItineraryChanged")]
        public bool ItineraryChanged { get; set; }

        [JsonProperty("ManualFare")]
        public bool ManualFare { get; set; }

        [JsonProperty("NegotiatedFare")]
        public bool NegotiatedFare { get; set; }

        [JsonProperty("SystemIndicator")]
        public string SystemIndicator { get; set; }

        [JsonProperty("NUCSuppresion")]
        public bool NucSuppresion { get; set; }

        [JsonProperty("SubjToGovtApproval")]
        public bool SubjToGovtApproval { get; set; }

        [JsonProperty("IT_BT_Fare")]
        public string ItBtFare { get; set; }

        [JsonProperty("DisplayOnly")]
        public bool DisplayOnly { get; set; }

        [JsonProperty("DiscountAmount")]
        public string DiscountAmount { get; set; }

        [JsonProperty("PassengerInfo")]
        public PassengerInfo PassengerInfo { get; set; }

        [JsonProperty("TicketingInstructionsInfo")]
        public TicketingInstructionsInfo TicketingInstructionsInfo { get; set; }
    }

    public partial class PassengerInfo
    {
        [JsonProperty("PassengerType")]
        public string PassengerType { get; set; }

        [JsonProperty("PassengerData")]
        public List<PassengerDatumElement> PassengerData { get; set; }
    }

    public partial class PassengerDatumElement
    {
        [JsonProperty("NameNumber")]
        public string NameNumber { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class TicketingInstructionsInfo
    {
    }

    public partial class PricedItineraryElement
    {
        [JsonProperty("DisplayOnly")]
        public bool DisplayOnly { get; set; }

        [JsonProperty("InputMessage")]
        public string InputMessage { get; set; }

        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("StatusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("TaxExempt")]
        public bool TaxExempt { get; set; }

        [JsonProperty("ValidatingCarrier")]
        public string ValidatingCarrier { get; set; }

        [JsonProperty("StoredDateTime")]
        public string StoredDateTime { get; set; }

        [JsonProperty("AirItineraryPricingInfo")]
        public PurpleAirItineraryPricingInfo AirItineraryPricingInfo { get; set; }
    }

    public partial class PurpleAirItineraryPricingInfo
    {
        [JsonProperty("ItinTotalFare")]
        public List<ItinTotalFareElement> ItinTotalFare { get; set; }

        [JsonProperty("PassengerTypeQuantity")]
        public List<PassengerTypeQuantity> PassengerTypeQuantity { get; set; }

        [JsonProperty("PTC_FareBreakdown")]
        public List<FluffyPtcFareBreakdown> PtcFareBreakdown { get; set; }
    }

    public partial class ItinTotalFareElement
    {
        [JsonProperty("BaseFare")]
        public BaseClass BaseFare { get; set; }

        [JsonProperty("EquivFare")]
        public BaseClass EquivFare { get; set; }

        [JsonProperty("Taxes")]
        public FluffyTaxes Taxes { get; set; }

        [JsonProperty("TotalFare")]
        public BaseClass TotalFare { get; set; }

        [JsonProperty("Totals")]
        public Totals Totals { get; set; }
    }

    public partial class FluffyTaxes
    {
        [JsonProperty("Tax")]
        public PurpleTax Tax { get; set; }

        [JsonProperty("TaxBreakdownCode")]
        public List<TaxBreakdownCode> TaxBreakdownCode { get; set; }
    }

    public partial class PurpleTax
    {
        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("TaxCode")]
        public string TaxCode { get; set; }
    }

    public partial class TaxBreakdownCode
    {
        [JsonProperty("TaxPaid")]
        public bool TaxPaid { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class Totals
    {
        [JsonProperty("BaseFare")]
        public TaxClass BaseFare { get; set; }

        [JsonProperty("EquivFare")]
        public TaxClass EquivFare { get; set; }

        [JsonProperty("Taxes")]
        public PriceQuoteTotalsTaxes Taxes { get; set; }

        [JsonProperty("TotalFare")]
        public TaxClass TotalFare { get; set; }
    }

    public partial class TaxClass
    {
        [JsonProperty("Amount")]
        public string Amount { get; set; }
    }

    public partial class PriceQuoteTotalsTaxes
    {
        [JsonProperty("Tax")]
        public TaxClass Tax { get; set; }
    }

    public partial class FluffyPtcFareBreakdown
    {
        [JsonProperty("Endorsements")]
        public Endorsements Endorsements { get; set; }

        [JsonProperty("FareBasis")]
        public List<Airline> FareBasis { get; set; }

        [JsonProperty("FareCalculation")]
        public ResponseHeader FareCalculation { get; set; }

        [JsonProperty("FareSource")]
        public string FareSource { get; set; }

        [JsonProperty("FlightSegment")]
        public List<PtcFareBreakdownFlightSegment> FlightSegment { get; set; }

        [JsonProperty("FareComponent")]
        public List<FareComponent> FareComponent { get; set; }
    }

    public partial class Endorsements
    {
        [JsonProperty("Endorsement")]
        public List<Endorsement> Endorsement { get; set; }
    }

    public partial class Endorsement
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    public partial class FareComponent
    {
        [JsonProperty("FareBasisCode")]
        public string FareBasisCode { get; set; }

        [JsonProperty("FareDirectionality")]
        public string FareDirectionality { get; set; }

        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("TicketDesignator")]
        public string TicketDesignator { get; set; }

        [JsonProperty("GoverningCarrier")]
        public string GoverningCarrier { get; set; }

        [JsonProperty("FareComponentNumber")]
        public string FareComponentNumber { get; set; }

        [JsonProperty("Location")]
        public Location Location { get; set; }

        [JsonProperty("Dates")]
        public Dates Dates { get; set; }

        [JsonProperty("FlightSegmentNumbers")]
        public FlightSegmentNumbers FlightSegmentNumbers { get; set; }
    }

    public partial class Dates
    {
        [JsonProperty("DepartureDateTime")]
        public string DepartureDateTime { get; set; }

        [JsonProperty("ArrivalDateTime")]
        public string ArrivalDateTime { get; set; }
    }

    public partial class FlightSegmentNumbers
    {
        [JsonProperty("FlightSegmentNumber")]
        public List<string> FlightSegmentNumber { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("Origin")]
        public string Origin { get; set; }

        [JsonProperty("Destination")]
        public string Destination { get; set; }
    }

    public partial class PtcFareBreakdownFlightSegment
    {
        [JsonProperty("ConnectionInd", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectionInd { get; set; }

        [JsonProperty("DepartureDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public string DepartureDateTime { get; set; }

        [JsonProperty("FlightNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string FlightNumber { get; set; }

        [JsonProperty("ResBookDesigCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ResBookDesigCode { get; set; }

        [JsonProperty("SegmentNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string SegmentNumber { get; set; }

        [JsonProperty("Status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("BaggageAllowance", NullValueHandling = NullValueHandling.Ignore)]
        public BaggageAllowance BaggageAllowance { get; set; }

        [JsonProperty("FareBasis", NullValueHandling = NullValueHandling.Ignore)]
        public Airline FareBasis { get; set; }

        [JsonProperty("MarketingAirline", NullValueHandling = NullValueHandling.Ignore)]
        public MarketingAirline MarketingAirline { get; set; }

        [JsonProperty("OriginLocation")]
        public FlightSegmentDestinationLocation OriginLocation { get; set; }

        [JsonProperty("ValidityDates", NullValueHandling = NullValueHandling.Ignore)]
        public ValidityDates ValidityDates { get; set; }
    }

    public partial class BaggageAllowance
    {
        [JsonProperty("Number")]
        public string Number { get; set; }
    }

    public partial class ValidityDates
    {
        [JsonProperty("NotValidAfter")]
        public string NotValidAfter { get; set; }

        [JsonProperty("NotValidBefore")]
        public string NotValidBefore { get; set; }
    }

    public partial class ReservationItems
    {
        [JsonProperty("Item")]
        public List<Item> Item { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("FlightSegment")]
        public List<ItemFlightSegment> FlightSegment { get; set; }

        [JsonProperty("Product")]
        public Product Product { get; set; }
    }

    public partial class ItemFlightSegment
    {
        [JsonProperty("AirMilesFlown")]
        public string AirMilesFlown { get; set; }

        [JsonProperty("ArrivalDateTime")]
        public string ArrivalDateTime { get; set; }

        [JsonProperty("DayOfWeekInd")]
        public string DayOfWeekInd { get; set; }

        [JsonProperty("DepartureDateTime")]
        public string DepartureDateTime { get; set; }

        [JsonProperty("SegmentBookedDate")]
        public string SegmentBookedDate { get; set; }

        [JsonProperty("ElapsedTime")]
        public string ElapsedTime { get; set; }

        [JsonProperty("eTicket")]
        public bool ETicket { get; set; }

        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("NumberInParty")]
        public string NumberInParty { get; set; }

        [JsonProperty("ResBookDesigCode")]
        public string ResBookDesigCode { get; set; }

        [JsonProperty("SegmentNumber")]
        public string SegmentNumber { get; set; }

        [JsonProperty("SmokingAllowed")]
        public bool SmokingAllowed { get; set; }

        [JsonProperty("SpecialMeal")]
        public bool SpecialMeal { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("StopQuantity")]
        public string StopQuantity { get; set; }

        [JsonProperty("IsPast")]
        public bool IsPast { get; set; }

        [JsonProperty("CodeShare")]
        public bool CodeShare { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("DestinationLocation")]
        public DestinationLocation DestinationLocation { get; set; }

        [JsonProperty("Equipment")]
        public Equipment Equipment { get; set; }

        [JsonProperty("MarketingAirline")]
        public TingAirline MarketingAirline { get; set; }

        [JsonProperty("Meal")]
        public List<Airline> Meal { get; set; }

        [JsonProperty("OperatingAirline")]
        public List<TingAirline> OperatingAirline { get; set; }

        [JsonProperty("OperatingAirlinePricing")]
        public Airline OperatingAirlinePricing { get; set; }

        [JsonProperty("DisclosureCarrier")]
        public DisclosureCarrier DisclosureCarrier { get; set; }

        [JsonProperty("OriginLocation")]
        public FlightSegmentDestinationLocation OriginLocation { get; set; }

        [JsonProperty("SupplierRef")]
        public Ref SupplierRef { get; set; }

        [JsonProperty("UpdatedArrivalTime")]
        public string UpdatedArrivalTime { get; set; }

        [JsonProperty("UpdatedDepartureTime")]
        public string UpdatedDepartureTime { get; set; }

        [JsonProperty("Cabin")]
        public FlightSegmentCabin Cabin { get; set; }
    }

    public partial class FlightSegmentCabin
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("SabreCode")]
        public string SabreCode { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ShortName")]
        public string ShortName { get; set; }

        [JsonProperty("Lang")]
        public string Lang { get; set; }
    }

    public partial class DestinationLocation
    {
        [JsonProperty("LocationCode")]
        public string LocationCode { get; set; }

        [JsonProperty("Terminal")]
        public string Terminal { get; set; }

        [JsonProperty("TerminalCode")]
        public string TerminalCode { get; set; }
    }

    public partial class DisclosureCarrier
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("DOT")]
        public bool Dot { get; set; }

        [JsonProperty("Banner")]
        public string Banner { get; set; }
    }

    public partial class Equipment
    {
        [JsonProperty("AirEquipType")]
        public string AirEquipType { get; set; }
    }

    public partial class TingAirline
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("ResBookDesigCode")]
        public string ResBookDesigCode { get; set; }

        [JsonProperty("Banner")]
        public string Banner { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("ProductDetails")]
        public ProductDetails ProductDetails { get; set; }
    }

    public partial class ProductDetails
    {
        [JsonProperty("productCategory")]
        public string ProductCategory { get; set; }

        [JsonProperty("ProductName")]
        public ProductName ProductName { get; set; }

        [JsonProperty("Air")]
        public Air Air { get; set; }
    }

    public partial class Air
    {
        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("segmentAssociationId")]
        public long SegmentAssociationId { get; set; }

        [JsonProperty("DepartureAirport")]
        public string DepartureAirport { get; set; }

        [JsonProperty("ArrivalAirport")]
        public string ArrivalAirport { get; set; }

        [JsonProperty("ArrivalTerminalName")]
        public string ArrivalTerminalName { get; set; }

        [JsonProperty("ArrivalTerminalCode")]
        public string ArrivalTerminalCode { get; set; }

        [JsonProperty("EquipmentType")]
        public string EquipmentType { get; set; }

        [JsonProperty("MarketingAirlineCode")]
        public string MarketingAirlineCode { get; set; }

        [JsonProperty("MarketingFlightNumber")]
        public string MarketingFlightNumber { get; set; }

        [JsonProperty("MarketingClassOfService")]
        public string MarketingClassOfService { get; set; }

        [JsonProperty("Cabin")]
        public AirCabin Cabin { get; set; }

        [JsonProperty("MealCode")]
        public List<string> MealCode { get; set; }

        [JsonProperty("ElapsedTime")]
        public long ElapsedTime { get; set; }

        [JsonProperty("AirMilesFlown")]
        public long AirMilesFlown { get; set; }

        [JsonProperty("FunnelFlight")]
        public bool FunnelFlight { get; set; }

        [JsonProperty("ChangeOfGauge")]
        public bool ChangeOfGauge { get; set; }

        [JsonProperty("DisclosureCarrier")]
        public DisclosureCarrier DisclosureCarrier { get; set; }

        [JsonProperty("AirlineRefId")]
        public string AirlineRefId { get; set; }

        [JsonProperty("Eticket")]
        public bool Eticket { get; set; }

        [JsonProperty("DepartureDateTime")]
        public string DepartureDateTime { get; set; }

        [JsonProperty("ArrivalDateTime")]
        public string ArrivalDateTime { get; set; }

        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("ClassOfService")]
        public string ClassOfService { get; set; }

        [JsonProperty("ActionCode")]
        public string ActionCode { get; set; }

        [JsonProperty("NumberInParty")]
        public long NumberInParty { get; set; }

        [JsonProperty("inboundConnection")]
        public bool InboundConnection { get; set; }

        [JsonProperty("outboundConnection")]
        public bool OutboundConnection { get; set; }

        [JsonProperty("ScheduleChangeIndicator")]
        public bool ScheduleChangeIndicator { get; set; }

        [JsonProperty("SegmentBookedDate")]
        public string SegmentBookedDate { get; set; }
    }

    public partial class AirCabin
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("sabreCode")]
        public string SabreCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public partial class ProductName
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class Ticketing
    {
        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("TicketTimeLimit")]
        public string TicketTimeLimit { get; set; }
    }

    public partial class ItineraryRef
    {
        [JsonProperty("AirExtras")]
        public bool AirExtras { get; set; }

        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("InhibitCode")]
        public string InhibitCode { get; set; }

        [JsonProperty("PartitionID")]
        public string PartitionId { get; set; }

        [JsonProperty("PrimeHostID")]
        public string PrimeHostId { get; set; }

        [JsonProperty("Header")]
        public List<string> Header { get; set; }

        [JsonProperty("Source")]
        public Source Source { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("AAA_PseudoCityCode")]
        public string AaaPseudoCityCode { get; set; }

        [JsonProperty("CreateDateTime")]
        public string CreateDateTime { get; set; }

        [JsonProperty("CreationAgent")]
        public string CreationAgent { get; set; }

        [JsonProperty("HomePseudoCityCode")]
        public string HomePseudoCityCode { get; set; }

        [JsonProperty("PseudoCityCode")]
        public string PseudoCityCode { get; set; }

        [JsonProperty("ReceivedFrom")]
        public string ReceivedFrom { get; set; }

        [JsonProperty("LastUpdateDateTime")]
        public string LastUpdateDateTime { get; set; }

        [JsonProperty("SequenceNumber")]
        public string SequenceNumber { get; set; }
    }

    public partial class OpenReservationElements
    {
        [JsonProperty("OpenReservationElement")]
        public List<OpenReservationElement> OpenReservationElement { get; set; }
    }

    public partial class OpenReservationElement
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("elementId")]
        public string ElementId { get; set; }

        [JsonProperty("ServiceRequest", NullValueHandling = NullValueHandling.Ignore)]
        public ServiceRequest ServiceRequest { get; set; }

        [JsonProperty("NameAssociation", NullValueHandling = NullValueHandling.Ignore)]
        public List<NameAssociation> NameAssociation { get; set; }

        [JsonProperty("SegmentAssociation", NullValueHandling = NullValueHandling.Ignore)]
        public List<SegmentAssociation> SegmentAssociation { get; set; }

        [JsonProperty("Email", NullValueHandling = NullValueHandling.Ignore)]
        public OpenReservationElementEmail Email { get; set; }
    }

    public partial class OpenReservationElementEmail
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }
    }

    public partial class NameAssociation
    {
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("ReferenceId")]
        public long ReferenceId { get; set; }

        [JsonProperty("NameRefNumber")]
        public string NameRefNumber { get; set; }
    }

    public partial class SegmentAssociation
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("SegmentAssociationId")]
        public string SegmentAssociationId { get; set; }

        [JsonProperty("AirSegment")]
        public AirSegment AirSegment { get; set; }
    }

    public partial class AirSegment
    {
        [JsonProperty("CarrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("DepartureDate")]
        public string DepartureDate { get; set; }

        [JsonProperty("BoardPoint")]
        public string BoardPoint { get; set; }

        [JsonProperty("OffPoint")]
        public string OffPoint { get; set; }

        [JsonProperty("ClassOfService")]
        public string ClassOfService { get; set; }

        [JsonProperty("BookingStatus")]
        public string BookingStatus { get; set; }
    }

    public partial class ServiceRequest
    {
        [JsonProperty("actionCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionCode { get; set; }

        [JsonProperty("airlineCode")]
        public string AirlineCode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("serviceCount", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceCount { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("ssrType")]
        public string SsrType { get; set; }

        [JsonProperty("FreeText")]
        public string FreeText { get; set; }

        [JsonProperty("FullText")]
        public string FullText { get; set; }

        [JsonProperty("TravelDocument", NullValueHandling = NullValueHandling.Ignore)]
        public TravelDocument TravelDocument { get; set; }

        [JsonProperty("PassengerContactMobilePhone", NullValueHandling = NullValueHandling.Ignore)]
        public PassengerContactMobilePhone PassengerContactMobilePhone { get; set; }

        [JsonProperty("PassengerContactEmail", NullValueHandling = NullValueHandling.Ignore)]
        public PassengerContactEmail PassengerContactEmail { get; set; }

        [JsonProperty("Comment", NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }
    }

    public partial class PassengerContactEmail
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }
    }

    public partial class PassengerContactMobilePhone
    {
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }
    }

    public partial class TravelDocument
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("DocumentIssueCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentIssueCountry { get; set; }

        [JsonProperty("DocumentNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentNumber { get; set; }

        [JsonProperty("DocumentNationalityCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentNationalityCountry { get; set; }

        [JsonProperty("DocumentExpirationDate", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentExpirationDate { get; set; }

        [JsonProperty("DateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("Infant")]
        public bool Infant { get; set; }

        [JsonProperty("PrimaryDocHolderInd", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PrimaryDocHolderInd { get; set; }

        [JsonProperty("HasDocumentData")]
        public bool HasDocumentData { get; set; }
    }

    public partial class SpecialServiceInfo
    {
        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Service")]
        public Service Service { get; set; }
    }

    public partial class Service
    {
        [JsonProperty("SSR_Code")]
        public string SsrCode { get; set; }

        [JsonProperty("SSR_Type", NullValueHandling = NullValueHandling.Ignore)]
        public string SsrType { get; set; }

        [JsonProperty("Airline")]
        public Airline Airline { get; set; }

        [JsonProperty("PersonName", NullValueHandling = NullValueHandling.Ignore)]
        public List<PassengerDatumElement> PersonName { get; set; }

        [JsonProperty("Text")]
        public List<string> Text { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }
    }
}
