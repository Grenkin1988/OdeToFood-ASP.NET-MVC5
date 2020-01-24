using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData {
        private readonly OneToFoodDbContext _db;

        public SqlRestaurantData(OneToFoodDbContext db) {
            _db = db;
        }

        public void Add(Restaurant restaurant) {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
        }

        public Restaurant Get(int id) {
            return _db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll() {
            return _db.Restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant) {
            var entry = _db.Entry(restaurant);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
