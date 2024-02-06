using NoteSharingApp.Entities;
using System.Data.Entity;

namespace NoteSharingApp.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EvernoteUser> EvernoteUsers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liked> Likes { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new Init());
        }
    }
}
