using Acceler.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acceler.Repository
{
    public class RideRepository
    {
        private List<Ride> testRides = new List<Ride>();
        public RideRepository()
        {
            this.testRides = new List<Ride>
            {
                new Ride {
                    Id = "1",
                Name = "Na putu prema Jadranu",
                Date = DateTime.Now,
                StartingPointLatitude = 45.8150,
                StartingPointLongitude = 15.9819,
                EndingPointLatitude = 45.4872,
                EndingPointLongitude = 15.5478,
                AvoidHighways = true,
                Waypoints = new List<Waypoint>(), // You can initialize Waypoints if needed
                Owner = new User(), // You can initialize Owner if needed
                Members = new List<User>() // You can initialize Members if needed
                },
                new Ride {
                    Id = "2",
                Name = "Seoskim putevima",
                Date = DateTime.Now,
                StartingPointLatitude = 45.7110,
                StartingPointLongitude = 16.0682,
                EndingPointLatitude = 45.4872,
                EndingPointLongitude = 15.5478,
                AvoidHighways = true,
                Waypoints = new List<Waypoint>(), // You can initialize Waypoints if needed
                Owner = new User(), // You can initialize Owner if needed
                Members = new List<User>() // You can initialize Members if needed
                },
                new Ride {
                Id = "3",
                Name = "Đir po centru",
                Date = DateTime.Now,
                StartingPointLatitude = 45.7110,
                StartingPointLongitude = 16.0682,
                EndingPointLatitude = 45.8150,
                EndingPointLongitude = 15.9819,
                AvoidHighways = true,
                Waypoints = new List<Waypoint>(), // You can initialize Waypoints if needed
                Owner = new User(), // You can initialize Owner if needed
                Members = new List<User>() // You can initialize Members if needed
                }
            };
        }

        public IList<Ride> GetRides()
        {
            return testRides;
        }

        public void CreateRide(Ride ride)
        {
            testRides.Add(ride);
        }

        public Ride GetRide(string rideId)
        {
            return testRides.FirstOrDefault(r => r.Id == rideId);
        }

        public void AddMemberToRide(User member, string rideId)
        {
            testRides.FirstOrDefault(r => r.Id == rideId).Members.Add(member);
        }
    }
}