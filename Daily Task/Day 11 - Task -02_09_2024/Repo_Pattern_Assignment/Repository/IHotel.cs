using Repo_Pattern_Assignment.Models;

namespace Repo_Pattern_Assignment.Repository
{
    public interface IHotel
    {
        IEnumerable<HotelModel> getall();

        void create(HotelModel Hotel);

    }
}
