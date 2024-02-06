using NoteSharingApp.BusinessLayer;
using NoteSharingApp.Entities;
using NoteSharingApp.Helpers;
using System;
using System.Web.Mvc;

namespace NoteSharingApp.Controllers
{
    public class NoteController : Controller
    {
        NoteManager nm = new NoteManager();
        [HttpPost]
        public ActionResult Post(Note note)
        {
            note.Owner = SessionHelpers.User;
            note.IsDraft = false;
            note.CreatedOn = DateTime.Now;
            note.ModifiedOn = note.CreatedOn;
            note.ModifiedUsername = SessionHelpers.User.Username;
            nm.Insert(note);

            return RedirectToAction("Profile", "User");
        }
    }
}