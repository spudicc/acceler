namespace Acceler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RideOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        StartingPointLatitude = c.Double(nullable: false),
                        StartingPointLongitude = c.Double(nullable: false),
                        EndingPointLatitude = c.Double(nullable: false),
                        EndingPointLongitude = c.Double(nullable: false),
                        AvoidHighways = c.Boolean(nullable: false),
                        RideOwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RideOwners", t => t.RideOwnerId)
                .Index(t => t.RideOwnerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Waypoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        IsStopover = c.Boolean(nullable: false),
                        RideId = c.String(),
                        Ride_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rides", t => t.Ride_Id)
                .Index(t => t.Ride_Id);
            
            CreateTable(
                "dbo.UserRides",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Ride_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Ride_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rides", t => t.Ride_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Ride_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RideOwners", "UserId", "dbo.Users");
            DropForeignKey("dbo.Waypoints", "Ride_Id", "dbo.Rides");
            DropForeignKey("dbo.Rides", "RideOwnerId", "dbo.RideOwners");
            DropForeignKey("dbo.UserRides", "Ride_Id", "dbo.Rides");
            DropForeignKey("dbo.UserRides", "User_Id", "dbo.Users");
            DropIndex("dbo.UserRides", new[] { "Ride_Id" });
            DropIndex("dbo.UserRides", new[] { "User_Id" });
            DropIndex("dbo.Waypoints", new[] { "Ride_Id" });
            DropIndex("dbo.Rides", new[] { "RideOwnerId" });
            DropIndex("dbo.RideOwners", new[] { "UserId" });
            DropTable("dbo.UserRides");
            DropTable("dbo.Waypoints");
            DropTable("dbo.Users");
            DropTable("dbo.Rides");
            DropTable("dbo.RideOwners");
        }
    }
}
