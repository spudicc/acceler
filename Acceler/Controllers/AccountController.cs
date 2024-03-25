using Acceler.Models;
using Acceler.Repository;
using System.Web.Mvc;
using System.Web.WebPages;
using Acceler.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Security;
using System.Linq;

namespace Acceler.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepository accountRepository = new AccountRepository();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = accountRepository.GetUser(model.Username, model.Password);

                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.FirstName + " " + result.LastName, false, "/");

                    Session["User"] = result.FirstName + " " + result.LastName;
                    Session["UserId"] = result.Id;

                    TempData["AlertTitle"] = "Uspješna prijava!";
                    TempData["AlertMessage"] = "Uživajte na Acceleru.";
                    TempData["AlertType"] = "success";

                    return RedirectToAction("Index", "Home");
                }

                TempData["AlertTitle"] = "Pogrešni podaci za prijavu.";
                TempData["AlertMessage"] = "Pokušajte ponovno.";
                TempData["AlertType"] = "error";
                return View(model);
            }


            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new RegisterDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    Phone = model.Phone,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = accountRepository.CreateUser(user);

                FormsAuthentication.SetAuthCookie(result.FirstName + " " + result.LastName, false, "/");

                Session["User"] = result.FirstName + " " + result.LastName;
                Session["UserId"] = result.Id;

                TempData["AlertTitle"] = "Uspješna prijava!";
                TempData["AlertMessage"] = "Uživajte na Acceleru.";
                TempData["AlertType"] = "success";

                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Registration went wrong.";
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult UserProfile(string id)
        {
            var result = accountRepository.GetUserProfile(id.AsInt());
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["UserId"] = null;

            FormsAuthentication.SignOut();

            TempData["AlertTitle"] = "Sada ste odjavljeni.";
            TempData["AlertMessage"] = "Vidimo se opet!";
            TempData["AlertType"] = "success";

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult EditProfile(string id)
        {
            var model = accountRepository.GetUserProfile(id.AsInt());
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditProfile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var updatedUser = accountRepository.UpdateUser(model);

            TempData["AlertTitle"] = "Uspješno ste uredili podatke.";
            TempData["AlertMessage"] = " ";
            TempData["AlertType"] = "success";

            return View("UserProfile", updatedUser);
        }

        [Authorize]
        public ActionResult Inbox(string id)
        {
            var currentUser = accountRepository.GetUser(id.AsInt());

            var allUsers = accountRepository.GetUsers().Where(u => u.Id != currentUser.Id);
            IList<UserChatViewModel> usersChatVM = new List<UserChatViewModel>();

            foreach (var user in allUsers)
            {
                var userChatVM = new UserChatViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };

                usersChatVM.Add(userChatVM);
            }

            var conversationViewModel = new ConversationViewModel
            {
                CurrentUser = currentUser,
                OtherUsers = usersChatVM
            };

            return View(conversationViewModel);
        }
    }
}