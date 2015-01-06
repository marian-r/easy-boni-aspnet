using System.Data.Entity;
using EasyBoni.Models.DAL.MySQL;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyBoni.Models.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Rating> Ratings { get; set; }
    }
}