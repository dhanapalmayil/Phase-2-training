using System.ComponentModel.DataAnnotations;

namespace API_Mini_Project_Recruitment_Agency_.Models
{
    public class ValidUser
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } 
        public string? Role { get; set; }
    }
}
