using OdeToFood.Data.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers {
    public class HomeController : Controller {
        private readonly IRestaurantData _db;

        public HomeController(IRestaurantData db) {
            _db = db;
        }

        public ActionResult Index() {
            IEnumerable<Data.Models.Restaurant> model = _db.GetAll();
            return View(model);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
