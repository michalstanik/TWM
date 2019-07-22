namespace TWM.Data.Domain.GeoEntities
{
    public class RegionStats
    {
        public int Id { get; set; }
        public int CountryCount { get; set; }

        public int RegionId {get;set;}
        public Region Region { get; set; }
    }
}
