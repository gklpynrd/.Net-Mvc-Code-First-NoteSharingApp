using NoteSharingApp.BusinessLayer;
using NoteSharingApp.BusinessLayer.Results;
using NoteSharingApp.Entities;
using NoteSharingApp.Entities.ValueObjects;
using NoteSharingApp.Helpers;
using NoteSharingApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace NoteSharingApp.Controllers
{
    public class UserController : Controller
    {
        static EvernoteUserManager eum = new EvernoteUserManager();
        static CategoryManager cm = new CategoryManager();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            BusinessLayerResult<EvernoteUser> result = eum.Login(model);

            if (result.Errors.Count > 0)
            {
                result.Errors.ForEach(x => ModelState.AddModelError("", x.message));
                return View(model);
            }

            SessionHelpers.Set("Login", result.Result);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            SessionHelpers.ClearSession();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            BusinessLayerResult<EvernoteUser> result = eum.Register(model);
            if (result.Errors.Count > 0)
            {
                result.Errors.ForEach(x => ModelState.AddModelError("", x.message));
                return View(model);
            }
            SessionHelpers.Set("Login", result.Result);
            return RedirectToAction("Index", "Home");
        }

        [ActionName("Profile")]
        public ActionResult UserProfile()
        {
            ProfileViewModel model = new ProfileViewModel();
            model.User = SessionHelpers.User;
            model.Notes = model.User.Notes.OrderByDescending(x => x.ModifiedOn).ToList();
            model.Categories = cm.List();
            return View(model);
        }
    }
}