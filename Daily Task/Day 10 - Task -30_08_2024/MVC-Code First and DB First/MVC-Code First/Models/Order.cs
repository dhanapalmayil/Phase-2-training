using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Code_First.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string? ProductName { get; set; }

        public DateTime? OrderDate { get; set; }

        public int custId { get; set; }

        [ForeignKey("custId")]

        public Customer? customer { get; set; }
    }
}
