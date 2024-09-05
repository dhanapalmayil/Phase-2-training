using Assessment_SocialMedia.Models;
namespace Assessment_SocialMedia.Repository
{
    public interface IUser
    {
        IEnumerable<User> getall();

        void create(User user);

        User details(int id);

        void edit(User user);

        void DeleteUser(int id);
      
    }
}
