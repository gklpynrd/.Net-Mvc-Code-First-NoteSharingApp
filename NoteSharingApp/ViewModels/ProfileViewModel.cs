using NoteSharingApp.Entities;
using System.Collections.Generic;

namespace NoteSharingApp.ViewModels
{
    public class ProfileViewModel
    {
        public EvernoteUser User { get; set; }
        public List<Note> Notes { get; set; }
        public List<Category> Categories { get; set; }
    }
}