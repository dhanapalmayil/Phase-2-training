using Assessment_SocialMedia.Models;
using Assessment_SocialMedia.Repository;
using Microsoft.EntityFrameworkCore;

namespace Assessment_SocialMedia.Services
{
    public class PostService : IPost
    {
        private readonly UserPostContext _context;

        public PostService(UserPostContext context)
        {
            _context = context;
        }

        public void create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var del = _context.Posts.Find(id);

            _context.Posts.Remove(del);
            
            _context.SaveChanges();
        }

        public Post details(int id)
        {
           
            return _context.Posts.Include(e => e.users).FirstOrDefault(e => e.PostId == id);
            
        }

        public void edit(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> getall()
        {
            return _context.Posts.Include(e=>e.users).ToList();
      
        }

        


    }
}
