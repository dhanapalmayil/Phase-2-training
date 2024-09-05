using System.ComponentModel.DataAnnotations;

namespace Assessment_SocialMedia.Models
{
    public class User
    {
        [Key]
        public int Uid { get; set; }    

        public string? UserName {  get; set; }

        public string? UserEmail { get; set; }

        public ICollection<Post>? posts { get; set; }
    }
}
