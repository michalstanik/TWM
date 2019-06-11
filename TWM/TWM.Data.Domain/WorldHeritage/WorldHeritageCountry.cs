using TWM.Data.Domain.GeoEntities;

namespace TWM.Data.Domain.WorldHeritage
{
    public class WorldHeritageCountry
    {
        public int WorldHeritageId { get; set; }
        public WorldHeritage WorldHeritage { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}