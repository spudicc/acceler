using Acceler.Models;
using Acceler.Repository;
using System.Reflection;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;

namespace Acceler.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepository accountRepository;

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            accountRepository = new AccountRepository();
            // Your login logic here
            // Validate credentials, authenticate user, etc.

            if (ModelState.IsValid)
            {
                var result = accountRepository.GetUser(model.Username, model.Password);

                if (result != null)
                {
                    Session["User"] = result.FirstName + " " + result.LastName;
                    Session["UserId"] = result.Id;

                    TempData["AlertTitle"] = "Login successful!";
                    TempData["AlertMessage"] = "Enjoy your stay.";
                    TempData["AlertType"] = "success";

                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["AlertTitle"] = "Something went wrong.";
            TempData["AlertMessage"] = "Try again?";
            TempData["AlertType"] = "error";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            // Your login logic here
            // Validate credentials, authenticate user, etc.

            if (ModelState.IsValid)
            {
                var result = accountRepository.CreateUser(model);

                if (result == 1)
                {
                    Session["User"] = model;

                    return RedirectToAction("Index", "Home");
                }

                TempData["ErrorMessage"] = "Registration went wrong.";
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Registration went wrong.";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserProfile(string id)
        {
            accountRepository = new AccountRepository();
            var result = accountRepository.GetUserById(id);
            return View(result);
        }
    }
}