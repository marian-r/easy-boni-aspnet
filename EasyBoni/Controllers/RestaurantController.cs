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
    }
}