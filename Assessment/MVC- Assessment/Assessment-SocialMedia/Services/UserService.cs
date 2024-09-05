using Assessment_SocialMedia.Models;
using Assessment_SocialMedia.Repository;
using Microsoft.EntityFrameworkCore;

namespace Assessment_SocialMedia.Services
{
    public class UserService : IUser
    {
        private readonly UserPostContext _context;

        public UserService(UserPostContext context)
        {
            _context = context;
        }

        public void create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var del= _context.Users.Find(id);
            _context.Users.Remove(del);
            _context.SaveChanges();
        }

        public IEnumerable<User> getall()
        {
            return _context.Users.Include(e=>e.posts).ToList();
        }

       
        User IUser.details(int id)
        {
            return _context.Users.Include(e => e.posts).FirstOrDefault(e => e.Uid == id);
        }

        void IUser.edit(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
