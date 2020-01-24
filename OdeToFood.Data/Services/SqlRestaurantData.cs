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
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db) {
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
            return from r in _db.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant) {
            var entry = _db.Entry(restaurant);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id) {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
        }
    }
}
