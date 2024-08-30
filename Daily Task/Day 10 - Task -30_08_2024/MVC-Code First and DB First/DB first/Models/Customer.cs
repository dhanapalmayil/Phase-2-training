using System;
using System.Collections.Generic;

namespace DB_first.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
