﻿using System.Collections.Generic;
using TWM.Data.Domain.Users;
using TWM.Data.Domain.WorldHeritage;

namespace TWM.Data.Domain.GeoEntities
{
    public class Country
    {
        public Country()
        {
            Locations = new List<Location>();
            WoldHeritageCountries = new List<WorldHeritageCountry>();
            UserCountryAssessments = new List<UserCountryAssessment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public long Area { get; set; }
        public List<Location> Locations { get; set; }

        public int? RegionId { get; set; }
        public Region Region { get; set; }

        public List<WorldHeritageCountry> WoldHeritageCountries { get; set; }
        public List<UserCountryAssessment> UserCountryAssessments { get; set; }
    }
}
