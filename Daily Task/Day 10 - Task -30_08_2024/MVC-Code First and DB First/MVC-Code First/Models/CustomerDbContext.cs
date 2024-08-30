using Microsoft.EntityFrameworkCore;
namespace MVC_Code_First.Models
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> orders { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) 
        { }
    }
}
