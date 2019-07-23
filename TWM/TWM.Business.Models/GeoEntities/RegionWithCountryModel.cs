using System.Collections.Generic;

namespace TWM.Business.Models.GeoEntities
{
    public class RegionWithCountryModel : RegionModel
    {
        public int Id { get; set; }
        public List<CountryModel> Countries { get; set; }
    }
}