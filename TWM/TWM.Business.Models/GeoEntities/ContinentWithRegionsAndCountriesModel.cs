using System.Collections.Generic;

namespace TWM.Business.Models.GeoEntities
{
    public class ContinentWithRegionsAndCountriesModel : ContinentModel
    {
        public List<RegionWithCountryModel> Regions { get; set; }
        public int StatsCountryCount { get; set; }
        public int VisitetCountriesOnContinent { get; set; }
    }
}
