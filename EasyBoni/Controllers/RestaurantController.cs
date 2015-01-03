using EasyBoni.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyBoni.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantsManager model = RestaurantsManager.Instance;

        public ActionResult Map()
        {
            return View();
        }

        // GET: Restaurant
        public ActionResult List()
        {
            return View(model.Restaurants);
        }

        public ActionResult GetList()
        {
            return Json(model.Restaurants, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<ActionResult> AddRating(int id, int value)
        {
            ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            ApplicationUserManager manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = await manager.FindByNameAsync(User.Identity.Name);

            var rating = new Rating()
            {
                RestaurantID = id,
                User = user,
                Value = value
            };

            db.Ratings.Add(rating);
            await db.SaveChangesAsync();

            Restaurant restaurant = model.Restaurants.Find(r => r.ID == id);
            
            return PartialView("_RatingPartial", restaurant);
        }
    }
}