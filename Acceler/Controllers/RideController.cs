using Acceler.Models;
using Acceler.Models.DTO;
using Acceler.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Acceler.Controllers
{
    [Authorize]
    public class RideController : Controller
    {
        RideRepository rideRepository = new RideRepository();

        AccountRepository accountRepository = new AccountRepository();

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RideDTO rideDTO)
        {
            var ride = new Ride
            {
                RideOwnerId = (int)Session["UserId"],
                Name = rideDTO.Name,
                StartingPointLatitude = Double.Parse(rideDTO.StartingPointLatitude, System.Globalization.CultureInfo.InvariantCulture),
                StartingPointLongitude = Double.Parse(rideDTO.StartingPointLongitude, System.Globalization.CultureInfo.InvariantCulture),
                EndingPointLatitude = Double.Parse(rideDTO.EndingPointLatitude, System.Globalization.CultureInfo.InvariantCulture),
                EndingPointLongitude = Double.Parse(rideDTO.EndingPointLongitude, System.Globalization.CultureInfo.InvariantCulture),
                AvoidHighways = rideDTO.AvoidHighways,
                Date = rideDTO.Date,
            };

            rideRepository.CreateRide(ride);
            rideRepository.CreateWaypoints(this.MapWaypoints(rideDTO.Waypoints));
            var result = rideRepository.GetRides();
            return View("Rides", result);
        }

        private ICollection<Waypoint> MapWaypoints(ICollection<Waypoint> waypoints)
        {
            IList<Waypoint> dbWaypoints = new List<Waypoint>();

            foreach (var waypoint in waypoints)
            {
                dbWaypoints.Add( new Waypoint
                {
                    RideId = rideRepository.GetRides().OrderByDescending(e => e.Id).FirstOrDefault().Id.ToString(),
                    Latitude = waypoint.Latitude,
                    Longitude = waypoint.Longitude,
                });
            }
            return dbWaypoints;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Rides() 
        {
            var result = rideRepository.GetRides();
            return View("Rides", result);
        }

        public ActionResult JoinRide(string rideId) 
        {
            var members = rideRepository.GetRide(rideId.AsInt()).RideMembers;

            bool memberCheck = members.Any(r => r.Id == (int)Session["UserId"]);

            if (memberCheck)
            {
                TempData["AlertTitle"] = "Već ste član ove vožnje.";
                TempData["AlertMessage"] = "Pridružite se nekoj novoj vožnji.";
                TempData["AlertType"] = "warning";
                return Rides();
            }

            var currentUser = accountRepository.GetUser((int)Session["UserId"]);
            rideRepository.AddMemberToRide(currentUser, rideId.AsInt());

            TempData["AlertTitle"] = "Uspješno ste se pridružili vožnji!";
            TempData["AlertMessage"] = "Preporučujemo kontakt s vlasnikom vožnje oko daljnjeg dogovora.";
            TempData["AlertType"] = "success";

            return Rides();
        }

        public ActionResult Details(string id)
        {
            var ride = rideRepository.GetRide(id.AsInt());
            return View(ride);
        }
    }
}