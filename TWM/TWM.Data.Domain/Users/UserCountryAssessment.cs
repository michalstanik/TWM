﻿using TWM.Data.Domain.GeoEntities;

namespace TWM.Data.Domain.Users
{
    public class UserCountryAssessment
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string TUserId { get; set; }
        public TUser TUser { get; set; }

        public long AreaLevelAssessment { get; set; }
        public CountryVisitType CountryKnowledgeType { get; set; }

        public enum CountryVisitType
        {
            BussinessTrip,
            JustVisit,
            Transfer,
            RealTrip
        }
    }
}