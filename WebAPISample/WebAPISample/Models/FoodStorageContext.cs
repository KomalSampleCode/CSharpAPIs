using Microsoft.EntityFrameworkCore;

namespace WebAPISample.Models
{
    public class FoodStorageContext : DbContext
    {
        public FoodStorageContext(DbContextOptions<FoodStorageContext> options) : base(options)
        {

        }

        public DbSet<FoodItem> foodItems { get; set; } = null;
    }
}