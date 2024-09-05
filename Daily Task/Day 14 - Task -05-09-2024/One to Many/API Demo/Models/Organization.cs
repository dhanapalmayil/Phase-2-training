using System.ComponentModel.DataAnnotations;

namespace API_Demo.Models
{
    public class Organization
    {
        [Key]
        public int OrgId { get; set; }

        public string? OrgName { get; set; }

        public ICollection<Employee>? Employees { get; set; }


    }
}
