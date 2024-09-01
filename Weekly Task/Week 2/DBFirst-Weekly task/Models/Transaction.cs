using System;
using System.Collections.Generic;

namespace DBFirst_Weekly_task.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? PropertyId { get; set; }

    public int? ClientId { get; set; }

    public string? TransactionType { get; set; }

    public DateTime? TransactionDate { get; set; }

    public virtual Property? Property { get; set; }
}
