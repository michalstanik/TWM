using System.Collections.Generic;

namespace TWM.Business.Models.GeoEntities
{
    public class RegionWithCountryModel : RegionModel
    {
        public List<CountryModel> Countries { get; set; }
    }
}