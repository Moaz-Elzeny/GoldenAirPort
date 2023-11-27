namespace GoldenAirport.Application.Trips.Dtos
{
    public class GetTripByIdDto
    {
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        
        public string TripHours { get; set; }
        public bool IsRefundable { get; set; }

        public GetFromCityDto FromCities { get; set; }
        public IEnumerable<GetCitiesDto> ToCities { get; set; }
        public IEnumerable<TripDescription> WhyVisit { get; set; }
        public IEnumerable<TripDescription> WhatIsIncluded { get; set; }
        public IEnumerable<TripDescription> Restrictions { get; set; }
        public IEnumerable<TripDescription> Accessibility { get; set; }
    }

    public class TripDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
