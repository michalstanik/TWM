using System.Collections.Generic;
using TWM.Data.Domain.Admin;
using TWM.Data.Domain.Stops;

namespace TWM.Data.Domain.GeoEntities
{
    public  class Location : AuditableEntity
    {
        public Location()
        {
            Stops = new List<Stop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Country Country { get; set; }
        public int? CountryId { get; set; }
        public List<Stop> Stops { get; set; }

        public int LocationTypeId { get; set; }
        public LocationType LocationType { get; set; }
    }
}