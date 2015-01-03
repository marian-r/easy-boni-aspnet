using EasyBoni.Models.MySQL;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EasyBoni.Models
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