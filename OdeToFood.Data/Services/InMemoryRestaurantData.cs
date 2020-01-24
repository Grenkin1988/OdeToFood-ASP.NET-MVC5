using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services {
    public class InMemoryRestaurantData : IRestaurantData {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData() {
            _restaurants = new List<Restaurant> {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French },
                new Restaurant { Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 4, Name = "KOLO", Cuisine = CuisineType.Vegan },
            };
        }

        public Restaurant Get(int id) {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll() {
            return _restaurants.OrderBy(r => r.Name);
        }

        public void Add(Restaurant restaurant) {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
        }

        public void Update(Restaurant restaurant) {
            Restaurant existing = Get(restaurant.Id);
            if(existing != null) {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }

        public void Delete(int id) {
            Restaurant existing = Get(id);
            if (existing != null) {
                _restaurants.Remove(existing);
            }
        }
    }
}
