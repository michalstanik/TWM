﻿using System.Collections.Generic;

namespace TWM.Data.Domain.GeoEntities
{
    public class Region
    {
        public Region()
        {
            Countries = new List<Country>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ContinentId { get; set; }
        public Continent Continent { get; set; }

        public RegionStats Stats { get; set; }

        public List<Country> Countries { get; set; }
    }
}
