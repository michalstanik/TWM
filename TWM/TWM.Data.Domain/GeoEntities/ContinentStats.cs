namespace TWM.Data.Domain.GeoEntities
{
    public class ContinentStats
    {
        public int Id { get; set; }   
        public int CountryCount { get; set; }

        public int ContinentId { get; set; }
        public Continent Continent { get; set; }
    }
}
