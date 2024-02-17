using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenAirport.Application.Flights.ThirdParty.Dtos.ShopeDto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Allowance
    {
        public int @ref { get; set; }
    }

    public class Arrival
    {
        public string airport { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string time { get; set; }
        public string terminal { get; set; }
        public int? dateAdjustment { get; set; }
    }

    public class BaggageAllowanceDesc
    {
        public int id { get; set; }
        public int pieceCount { get; set; }
        public string description1 { get; set; }
        public string description2 { get; set; }
        public int? weight { get; set; }
        public string unit { get; set; }
    }

    public class BaggageInformation
    {
        public string provisionType { get; set; }
        public string airlineCode { get; set; }
        public List<Segment> segments { get; set; }
        public Allowance allowance { get; set; }
    }

    public class Carrier
    {
        public string marketing { get; set; }
        public int marketingFlightNumber { get; set; }
        public string operating { get; set; }
        public int operatingFlightNumber { get; set; }
        public Equipment equipment { get; set; }
        public string alliances { get; set; }
    }

    public class CurrencyConversion
    {
        public string from { get; set; }
        public string to { get; set; }
        public double exchangeRateUsed { get; set; }
    }

    public class Default
    {
        public string code { get; set; }
    }

    public class Departure
    {
        public string airport { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string time { get; set; }
        public string terminal { get; set; }
    }

    public class DiversitySwapper
    {
        public double weighedPrice { get; set; }
    }

    public class Equipment
    {
        public string code { get; set; }
        public string typeForFirstLeg { get; set; }
        public string typeForLastLeg { get; set; }
    }

    public class Fare
    {
        public string validatingCarrierCode { get; set; }
        public bool vita { get; set; }
        public bool eTicketable { get; set; }
        public string lastTicketDate { get; set; }
        public string lastTicketTime { get; set; }
        public string governingCarriers { get; set; }
        public List<PassengerInfoList> passengerInfoList { get; set; }
        public TotalFare totalFare { get; set; }
        public List<ValidatingCarrier> validatingCarriers { get; set; }
    }

    public class FareComponent
    {
        public int @ref { get; set; }
        public string beginAirport { get; set; }
        public string endAirport { get; set; }
        public List<Segment> segments { get; set; }
    }

    public class FareComponentDesc
    {
        public int id { get; set; }
        public string governingCarrier { get; set; }
        public double fareAmount { get; set; }
        public string fareCurrency { get; set; }
        public string fareBasisCode { get; set; }
        public string farePassengerType { get; set; }
        public string ticketDesignator { get; set; }
        public double publishedFareAmount { get; set; }
        public bool negotiatedFare { get; set; }
        public bool privateFare { get; set; }
        public string directionality { get; set; }
        public string direction { get; set; }
        public string notValidBefore { get; set; }
        public string notValidAfter { get; set; }
        public string applicablePricingCategories { get; set; }
        public string vendorCode { get; set; }
        public string fareTypeBitmap { get; set; }
        public string fareType { get; set; }
        public string fareTariff { get; set; }
        public string fareRule { get; set; }
        public string cabinCode { get; set; }
        public List<Segment> segments { get; set; }
        public int? mileageSurcharge { get; set; }
        public bool? mileage { get; set; }
    }

    public class GroupDescription
    {
        public List<LegDescription> legDescriptions { get; set; }
    }

    public class GroupedItineraryResponse
    {
        public string version { get; set; }
        public List<Message> messages { get; set; }
        public Statistics statistics { get; set; }
        public List<ScheduleDesc> scheduleDescs { get; set; }
        public List<TaxDesc> taxDescs { get; set; }
        public List<TaxSummaryDesc> taxSummaryDescs { get; set; }
        public List<ObFeeDesc> obFeeDescs { get; set; }
        public List<FareComponentDesc> fareComponentDescs { get; set; }
        public List<ValidatingCarrierDesc> validatingCarrierDescs { get; set; }
        public List<BaggageAllowanceDesc> baggageAllowanceDescs { get; set; }
        public List<LegDesc> legDescs { get; set; }
        public List<ItineraryGroup> itineraryGroups { get; set; }
    }

    public class Itinerary
    {
        public int id { get; set; }
        public string pricingSource { get; set; }
        public List<Leg> legs { get; set; }
        public List<PricingInformation> pricingInformation { get; set; }
        public DiversitySwapper diversitySwapper { get; set; }
    }

    public class ItineraryGroup
    {
        public GroupDescription groupDescription { get; set; }
        public List<Itinerary> itineraries { get; set; }
    }

    public class Leg
    {
        public int @ref { get; set; }
    }

    public class LegDesc
    {
        public int id { get; set; }
        public int elapsedTime { get; set; }
        public List<Schedule> schedules { get; set; }
    }

    public class LegDescription
    {
        public string departureDate { get; set; }
        public string departureLocation { get; set; }
        public string arrivalLocation { get; set; }
    }

    public class Message
    {
        public string severity { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string text { get; set; }
    }

    public class ObFeeDesc
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class PassengerInfo
    {
        public string passengerType { get; set; }
        public int passengerNumber { get; set; }
        public bool nonRefundable { get; set; }
        public List<FareComponent> fareComponents { get; set; }
        public List<Taxis> taxes { get; set; }
        public List<TaxSummary> taxSummaries { get; set; }
        public CurrencyConversion currencyConversion { get; set; }
        public PassengerTotalFare passengerTotalFare { get; set; }
        public List<BaggageInformation> baggageInformation { get; set; }
        public PenaltiesInfo penaltiesInfo { get; set; }
    }

    public class PassengerInfoList
    {
        public PassengerInfo passengerInfo { get; set; }
    }

    public class PassengerTotalFare
    {
        public double totalFare { get; set; }
        public double totalTaxAmount { get; set; }
        public string currency { get; set; }
        public double baseFareAmount { get; set; }
        public string baseFareCurrency { get; set; }
        public double equivalentAmount { get; set; }
        public string equivalentCurrency { get; set; }
        public double constructionAmount { get; set; }
        public string constructionCurrency { get; set; }
        public double commissionPercentage { get; set; }
        public double commissionAmount { get; set; }
        public double exchangeRateOne { get; set; }
    }

    public class PenaltiesInfo
    {
        public List<Penalty> penalties { get; set; }
    }

    public class Penalty
    {
        public string type { get; set; }
        public string applicability { get; set; }
        public bool changeable { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public bool cat16Info { get; set; }
        public bool? refundable { get; set; }
    }

    public class PricingInformation
    {
        public string pricingSubsource { get; set; }
        public Fare fare { get; set; }
    }

    public class ShoppingResponseDto
    {
        public GroupedItineraryResponse groupedItineraryResponse { get; set; }
    }

    public class Schedule
    {
        public int @ref { get; set; }
        public int? departureDateAdjustment { get; set; }
    }

    public class ScheduleDesc
    {
        public int id { get; set; }
        public string frequency { get; set; }
        public int stopCount { get; set; }
        public bool eTicketable { get; set; }
        public int totalMilesFlown { get; set; }
        public int elapsedTime { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public Carrier carrier { get; set; }
    }

    public class Segment
    {
        public Segment segment { get; set; }
        public int id { get; set; }
    }

    public class Segment2
    {
        public bool stopover { get; set; }
        public string bookingCode { get; set; }
        public string cabinCode { get; set; }
        public string mealCode { get; set; }
        public int seatsAvailable { get; set; }
        public bool availabilityBreak { get; set; }
        public bool fareBreakPoint { get; set; }
    }

    public class Statistics
    {
        public int itineraryCount { get; set; }
    }

    public class TaxDesc
    {
        public int id { get; set; }
        public string code { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public double publishedAmount { get; set; }
        public string publishedCurrency { get; set; }
        public string station { get; set; }
        public string country { get; set; }
    }

    public class Taxis
    {
        public int @ref { get; set; }
    }

    public class TaxSummary
    {
        public int @ref { get; set; }
    }

    public class TaxSummaryDesc
    {
        public int id { get; set; }
        public string code { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public double publishedAmount { get; set; }
        public string publishedCurrency { get; set; }
        public string station { get; set; }
        public string country { get; set; }
    }

    public class TotalFare
    {
        public double totalPrice { get; set; }
        public double totalTaxAmount { get; set; }
        public string currency { get; set; }
        public double baseFareAmount { get; set; }
        public string baseFareCurrency { get; set; }
        public double constructionAmount { get; set; }
        public string constructionCurrency { get; set; }
        public double equivalentAmount { get; set; }
        public string equivalentCurrency { get; set; }
    }

    public class ValidatingCarrier
    {
        public int @ref { get; set; }
    }

    public class ValidatingCarrierDesc
    {
        public int id { get; set; }
        public string settlementMethod { get; set; }
        public bool newVcxProcess { get; set; }
        public Default @default { get; set; }
    }


}
