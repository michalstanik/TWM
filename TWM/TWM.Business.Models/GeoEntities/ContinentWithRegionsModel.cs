using System.Collections.Generic;

namespace TWM.Business.Models.GeoEntities
{
    public class ContinentWithRegionsModel : ContinentModel
    {
        public List<RegionModel> Regions {get;set;}
    }
}
