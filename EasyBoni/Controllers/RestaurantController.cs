using EasyBoni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyBoni.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantsManager model = RestaurantsManager.Instance;

        // GET: Restaurant
        public ActionResult List()
        {
            return View(model.Restaurants);
        }
    }
}