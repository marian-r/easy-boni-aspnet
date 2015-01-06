using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace EasyBoni.Models.DAL
{
    public class RatingsManager
    {
        private ApplicationDbContext db;

        public RatingsManager()
        {
            db = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
        }

        public Dictionary<int, double> FindForAllRestaurants()
        {
            return db.Ratings.GroupBy(r => r.RestaurantID)
                .Select(g => new
                {
                    ID = g.Key,
                    Average = g.Average(p => p.Value),
                })
                .ToDictionary(i => i.ID, i => i.Average);
        }
    }
}