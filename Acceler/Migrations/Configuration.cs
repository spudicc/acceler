namespace Acceler.Migrations
{
    using Acceler.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Acceler.DAL.AccelerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Acceler.DAL.AccelerDbContext context)
        {
            context.Rides.RemoveRange(context.Rides);
            context.RideOwners.RemoveRange(context.RideOwners);
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();

            var users = new List<User>
            {
            new User { Id = 1, Username = "user1", Password = "pw", FirstName = "Marina", LastName= "Spudic", Email = "user1@example.com", Phone = "1234567890"},
            new User { Id = 2, Username = "user2", Password = "pw", FirstName = "Marc", LastName= "Marquez", Email = "user2@example.com", Phone = "9876543210"},
            new User { Id = 3, Username = "user3", Password = "pw", FirstName = "Fabio", LastName= "Quartararo", Email = "user3@example.com", Phone = "5555555555"},
            };

            users.ForEach(s => context.Users.AddOrUpdate(s));

            context.SaveChanges();

            var owners = new List<RideOwner>
            {
                new RideOwner { UserId= context.Users.First().Id }
            };

            owners.ForEach(o => context.RideOwners.AddOrUpdate(o));

            context.SaveChanges();

            var rides = new List<Ride>
            {
                new Ride
                {
                    Id = 1,
                    Name = "Na putu prema Jadranu",
                    Date = DateTime.Now,
                    StartingPointLatitude = 45.8150,
                    StartingPointLongitude = 15.9819,
                    EndingPointLatitude = 45.4872,
                    EndingPointLongitude = 15.5478,
                    AvoidHighways = true,
                    RideOwner = context.RideOwners.First()
                },
                new Ride
                {
                     Id = 2,
                     Name = "Seoskim putevima",
                     Date = DateTime.Now,
                     StartingPointLatitude = 45.7110,
                     StartingPointLongitude = 16.0682,
                     EndingPointLatitude = 45.4872,
                     EndingPointLongitude = 15.5478,
                     AvoidHighways = true,
                     RideOwner = context.RideOwners.First()
                },
                new Ride 
                {
                     Id = 3,
                     Name = "Đir po centru",
                     Date = DateTime.Now,
                     StartingPointLatitude = 45.7110,
                     StartingPointLongitude = 16.0682,
                     EndingPointLatitude = 45.8150,
                     EndingPointLongitude = 15.9819,
                     AvoidHighways = true,
                     RideOwner = context.RideOwners.First()
                }
            };

            rides.ForEach(r => context.Rides.AddOrUpdate(r));

            context.SaveChanges();
        }
    }
}
