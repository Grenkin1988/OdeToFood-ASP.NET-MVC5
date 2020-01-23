using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;

namespace OdeToFood.Data.Services {
    public class OneToFoodDbContext {
        public List<Restaurant> Restaurants { get; internal set; }

        internal void SaveChanges() {
        }
    }
}
