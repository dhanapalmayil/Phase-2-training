using System;
using System.Collections.Generic;

namespace DBFirst_Weekly_task.Models;

public partial class Property
{
    public int PropertyId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? ImagePath { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
