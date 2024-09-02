using Repo_Pattern_Assignment.Models;

namespace Repo_Pattern_Assignment.Repository
{
    public interface IRoom
    {
        IEnumerable<RoomModel> GetAll();

       
        void create(RoomModel room);
    }
}
