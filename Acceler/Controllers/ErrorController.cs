using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acceler.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public ActionResult Unauthorized()
        {
            TempData["AlertTitle"] = "Morate biti član da biste pristupili ovom dijelu aplikacije.";
            TempData["AlertMessage"] = "Bit ćete preusmjereni na ekran za prijavu.";
            TempData["AlertType"] = "warning";

            return RedirectToAction("Index", "Home");
        }
    }
}