﻿using System.Collections.Generic;

namespace TWM.Data.Domain.Trips
{
    public class TripType
    {
        public TripType()
        {
            Trips = new List<Trip>();
        }
        public int Id { get; set; }
        public string TripTypeName { get; set; }

        public List<Trip> Trips { get; set; }
    }
}