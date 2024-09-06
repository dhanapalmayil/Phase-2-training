﻿using System.ComponentModel.DataAnnotations;

namespace API_Demo.Models
{
    public class ValidUser
    {
        [Key]
        public int userId { get; set; }

        public string? userName { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

        public string? role { get; set; }
    }
}
