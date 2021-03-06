﻿using TWM.Data.Domain.Trips;

namespace TWM.Data.Domain.Users
{
    public class UserTrip
    {
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public string TUserId { get; set; }
        public TUser TUser { get; set; }

        public bool IsOrganiser { get; set; }
        public bool IsMain { get; set; }
    }
}
