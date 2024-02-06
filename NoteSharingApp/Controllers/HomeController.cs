using NoteSharingApp.BusinessLayer;
using System.Linq;
using System.Web.Mvc;


namespace NoteSharingApp.Controllers
{
    public class HomeController : Controller
    {
        private static NoteManager nm = new NoteManager();
        // GET: Home
        public ActionResult Index()
        {

            return View(nm.List());
        }

        public ActionResult MostLiked()
        {
            return View(nm.ListQueryable().OrderByDescending(x => x.LikeCount).ToList());
        }

        public ActionResult LastEntries()
        {
            return View(nm.ListQueryable().OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}