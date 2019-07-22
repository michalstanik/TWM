using System.Collections.Generic;

namespace TWM.Data.Domain.GeoEntities
{
    public class Continent
    {
        public Continent()
        {
            Regions = new List<Region>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ContinentStats Stats { get; set; }
        public List<Region> Regions { get; set; }
    }
}