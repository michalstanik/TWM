﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWM.Data.Domain.Admin;
using TWM.Data.Domain.Stops;
using TWM.Data.Domain.Users;

namespace TWM.Data.Domain.Trips
{
    public class Trip : AuditableEntity
    {
        public Trip()
        {
            Stops = new List<Stop>();
            UserTrips = new List<UserTrip>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TripCode { get; set; }
        public double StarRating { get; set; }

        public List<Stop> Stops { get; set; }
        public List<UserTrip> UserTrips { get; set; }

        public TUser TripManager { get; set; }

        public TripType TripType { get; set; }

        public IEnumerable<TUser> Users()
        {
            var users = new List<TUser>();
            foreach (var join in UserTrips)
            {
                users.Add(join.TUser);
            }
            return users;
        }
    }
}
