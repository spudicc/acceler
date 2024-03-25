using Acceler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acceler.DAL
{
    public class AccelerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AccelerDbContext>
    {
        protected override void Seed(AccelerDbContext context)
        {
            var users = new List<User>
            {
            new User { Username = "user1", Password = "pw", FirstName = "Marina", LastName= "Spudic", Email = "user1@example.com", Phone = "1234567890" },
            new User { Username = "user2", Password = "pw", FirstName = "Dado", LastName= "Spudic", Email = "user2@example.com", Phone = "9876543210" },
            new User { Username = "user3", Password = "pw", FirstName = "Alic", LastName= "Dautovic", Email = "user3@example.com", Phone = "5555555555" },
            };

            var rideOwners = new List<RideOwner>
            {
            new RideOwner { UserId = 1, CreatedRides = new List<Ride>() },
            new RideOwner { UserId = 2, CreatedRides = new List<Ride>() },
            new RideOwner { UserId = 3, CreatedRides = new List<Ride>() },
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var rides = new List<Ride>
            {
            new Ride {
                Name = "Na putu prema Jadranu",
                Date = DateTime.Now,
                StartingPointLatitude = 45.8150,
                StartingPointLongitude = 15.9819,
                EndingPointLatitude = 45.4872,
                EndingPointLongitude = 15.5478,
                AvoidHighways = true,
                Waypoints = new List<Waypoint>(), // You can initialize Waypoints if needed
                },
                new Ride {
                Name = "Seoskim putevima",
                Date = DateTime.Now,
                StartingPointLatitude = 45.7110,
                StartingPointLongitude = 16.0682,
                EndingPointLatitude = 45.4872,
                EndingPointLongitude = 15.5478,
                AvoidHighways = true,
                Waypoints = new List<Waypoint>(), // You can initialize Waypoints if needed
                },
                new Ride {
                Name = "Đir po centru",
                Date = DateTime.Now,
                StartingPointLatitude = 45.7110,
                StartingPointLongitude = 16.0682,
                EndingPointLatitude = 45.8150,
                EndingPointLongitude = 15.9819,
                AvoidHighways = true,
                Waypoints = new List<Waypoint>(), // You can initialize Waypoints if needed
                }
            };
            rides.ForEach(s => context.Rides.Add(s));
            context.SaveChanges();

            var waypoints = new List<Waypoint>
            {
                new Waypoint { Latitude = 45.632363, Longitude = 15.608354, IsStopover = true, RideId = context.Rides.First().Id.ToString() }
            };

            waypoints.ForEach(s => context.Waypoints.Add(s));
            context.SaveChanges();
        }
    }
}
