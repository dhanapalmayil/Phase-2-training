﻿using System;
using System.Collections.Generic;

namespace DB_first.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? ProductName { get; set; }

    public DateTime? OrderDate { get; set; }

    public int CustId { get; set; }

    public virtual Customer Cust { get; set; } = null!;
}
