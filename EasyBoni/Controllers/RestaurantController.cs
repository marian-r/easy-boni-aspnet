using EasyBoni.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections;
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
        public ActionResult List(string query, RestaurantsOrder order = RestaurantsOrder.Name)
        {
            IEnumerable<Restaurant> restaurants = model.Restaurants;

            if (!string.IsNullOrWhiteSpace(query))
            {
                restaurants = restaurants.Where(r => r.Name.ToLower().Contains(query.ToLower()));
            }

            switch (order)
            {
                case RestaurantsOrder.Name:
                    restaurants = restaurants.OrderBy(r => r.Name);
                    break;
                case RestaurantsOrder.Price:
                    restaurants = restaurants.OrderBy(r => r.Price);
                    break;
                case RestaurantsOrder.Rating:
                    restaurants = restaurants.OrderByDescending(r => r.Rating);
                    break;
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_RestaurantsList", restaurants);
            }

            return View(restaurants);
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