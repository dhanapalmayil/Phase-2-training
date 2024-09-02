using Microsoft.EntityFrameworkCore;
using Repo_Pattern_Assignment.Models;
using Repo_Pattern_Assignment.Repository;
using System.Runtime.CompilerServices;

namespace Repo_Pattern_Assignment.Service
{
    public class HotelService : IHotel
    {
        private readonly HotellDbContext _context;

        public HotelService(HotellDbContext context)
        {
                _context = context;
        }

        public IEnumerable<HotelModel> getall()
        {
            return _context.Hotels.Include(o=>o.Room).ToList();
        }

        

        public void create(HotelModel Hotel)
        {
            _context.Hotels.Add(Hotel);
            _context.SaveChanges();
        }
    }
}
