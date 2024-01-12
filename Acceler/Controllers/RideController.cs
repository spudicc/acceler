using Acceler.Models;
using Acceler.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acceler.Controllers
{
    public class RideController : Controller
    {
        RideRepository rideRepository = new RideRepository();

        AccountRepository accountRepository = new AccountRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create() 
        {
            if (Session["User"] != null)
            {
                ViewBag.User = Session["User"];
                ViewBag.UserId = Session["UserId"];
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Ride ride)
        {
            ride.Owner = accountRepository.GetUserById(Session["UserId"].ToString());
            ride.Members = new List<User>();
            rideRepository.CreateRide(ride);
            var result = rideRepository.GetRides();
            return View("Rides", result);
        }

        [HttpGet]
        public ActionResult Rides() 
        {
            if (Session["User"] == null)
            {
                TempData["AlertTitle"] = "Morate biti član da biste vidjeli vožnje.";
                TempData["AlertMessage"] = "Bit ćete preusmjereni na ekran za prijavu.";
                TempData["AlertType"] = "warning";
                return RedirectToAction("Login", "Account");
            }

            if (Session["User"] != null)
            {
                ViewBag.User = Session["User"];
                ViewBag.UserId = Session["UserId"];
            }

            var result = rideRepository.GetRides();
            return View("Rides", result);
        }

        public ActionResult JoinRide(string rideId) 
        {
            var members = rideRepository.GetRide(rideId).Members;

            bool memberCheck = members.Any(r => r.Id == Session["UserId"].ToString());

            if (memberCheck)
            {
                TempData["AlertTitle"] = "Već ste član ove vožnje.";
                TempData["AlertMessage"] = "Pridružite se nekoj novoj vožnji.";
                TempData["AlertType"] = "warning";
                return Rides();
            }

            var currentUser = accountRepository.GetUserById(Session["UserId"].ToString());
            rideRepository.AddMemberToRide(currentUser, rideId);

            TempData["AlertTitle"] = "Uspješno ste se pridružili vožnji!";
            TempData["AlertMessage"] = "Preporučujemo kontakt s vlasnikom vožnje oko daljnjeg dogovora.";
            TempData["AlertType"] = "success";

            return Rides();
        }
    }
}