using System;
using TWM.Data.Domain.Admin;
using TWM.Data.Domain.GeoEntities;
using TWM.Data.Domain.Trips;

namespace TWM.Data.Domain.Stops
{
    public class Stop : AuditableEntity
    {
        public int Id { get; set; }
        public string StopName { get; set; }
        public string StopDescription { get; set; }
        public int Order { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }
    }
}
