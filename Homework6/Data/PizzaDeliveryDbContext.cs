using Microsoft.EntityFrameworkCore;

namespace Homework4.Data
{
    public class PizzaDeliveryDbContext : DbContext
    {
        public PizzaDeliveryDbContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Order> Orders { get; set; }
    }
}
