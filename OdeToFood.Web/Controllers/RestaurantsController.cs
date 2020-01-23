using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers {
    public class RestaurantsController : Controller {
        private readonly IRestaurantData _db;

        public RestaurantsController(IRestaurantData db) {
            _db = db;
        }

        public ActionResult Index() {
            IEnumerable<Restaurant> model = _db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id) {
            Restaurant model = _db.Get(id);
            if(model == null) {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant) {
            if (ModelState.IsValid) {
                _db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            Restaurant model = _db.Get(id);
            if (model == null) {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant) {
            if (ModelState.IsValid) {
                _db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }
    }
}
