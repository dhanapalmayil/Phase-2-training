using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Demo.Models
{
    public class Employee
    {
        [Key]
        public int empId {  get; set; } 

        public string? empName { get; set; }

        public int empSalary { get; set; }


       
        public int OrgId {  get; set; }
        [ForeignKey("OrgId")]
        public Organization? organization { get; set; }
    }
}
