using System;
using System.Collections.Generic;

namespace DBFirst_Weekly_task.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? UserType { get; set; }
}
