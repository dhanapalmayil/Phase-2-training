using Microsoft.EntityFrameworkCore;
using Repo_Pattern_Assignment.Models;
using Repo_Pattern_Assignment.Repository;
using System.Runtime.CompilerServices;

namespace Repo_Pattern_Assignment.Service
{
    public class RoomService : IRoom
    {
        private readonly HotellDbContext _context;

        public RoomService(HotellDbContext context)
        {
                _context = context;
        }


        public void create(RoomModel room)
        {
            _context.Add(room);
            _context.SaveChanges();
        }

        public IEnumerable<RoomModel> GetAll()
        {
            return _context.Rooms.Include(e=>e.HotelModel).ToList();

        }
    }
}
