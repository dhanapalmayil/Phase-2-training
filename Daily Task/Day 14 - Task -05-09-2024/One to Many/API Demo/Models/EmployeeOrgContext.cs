using Microsoft.EntityFrameworkCore;

namespace API_Demo.Models
{
    public class EmployeeOrgContext: DbContext

    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public EmployeeOrgContext(DbContextOptions<EmployeeOrgContext> options) : base(options) { 
        

        }
    }
}
