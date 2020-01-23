﻿using OdeToFood.Data.Models;
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
            return View(model);
        }
    }
}