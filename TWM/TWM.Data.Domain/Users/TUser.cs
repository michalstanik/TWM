using System.Collections.Generic;

namespace TWM.Data.Domain.Users
{
    public class TUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }
        public List<UserTrip> UserTrips { get; set; }
        public List<UserCountryAssessment> UserCountryAssessments { get; set; }
    }
}
