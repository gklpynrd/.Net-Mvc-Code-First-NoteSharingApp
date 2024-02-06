using NoteSharingApp.BusinessLayer;
using System.Linq;
using System.Web.Mvc;

namespace NoteSharingApp.Controllers
{
    public class CategoryController : Controller
    {
        private static NoteManager nm = new NoteManager();
        // GET: Category
        public ActionResult Select(int id = 0)
        {
            return View(nm.List(x => x.CategoryId == id).ToList());
        }
    }
}