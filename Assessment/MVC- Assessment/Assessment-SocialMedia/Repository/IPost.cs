using Assessment_SocialMedia.Models;

namespace Assessment_SocialMedia.Repository
{
    public interface IPost
    {

        IEnumerable<Post> getall();

        void create(Post post);

        Post details(int id);

        void edit(Post post);

        void DeleteUser(int id);
    }
}
