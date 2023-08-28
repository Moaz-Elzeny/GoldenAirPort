namespace GoldenAirport.Domain.Entities
{
    public class WhatIsIncluded
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int TripId { get; set; }
        public virtual Trip Trips { get; set; }
    }
}
