using OdeToFood.Data.Models;
using System.Data.Entity;

namespace OdeToFood.Data.Services {
    public class OneToFoodDbContext : DbContext {
        public DbSet<Restaurant> Restaurants { get; internal set; }
    }
}
