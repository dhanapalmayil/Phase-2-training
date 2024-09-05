using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment_SocialMedia.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UserId {  get; set; }
        [ForeignKey("UserId")]
        public User? users { get; set; }
    }
}
