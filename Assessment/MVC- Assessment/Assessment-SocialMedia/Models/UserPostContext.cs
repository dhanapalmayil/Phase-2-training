using Microsoft.EntityFrameworkCore;
namespace Assessment_SocialMedia.Models
{
    public class UserPostContext :DbContext

    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post > Posts { get; set; }

        public UserPostContext(DbContextOptions<UserPostContext> options) : base(options) { }
    }
}
