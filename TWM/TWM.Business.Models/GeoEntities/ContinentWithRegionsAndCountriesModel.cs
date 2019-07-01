using System.Collections.Generic;

namespace TWM.Business.Models.GeoEntities
{
    public class ContinentWithRegionsAndCountriesModel : ContinentModel
    {
        public List<RegionWithCountryModel> Regions { get; set; }
    }
}
