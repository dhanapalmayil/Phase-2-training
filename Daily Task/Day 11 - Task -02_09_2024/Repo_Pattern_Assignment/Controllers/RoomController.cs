using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repo_Pattern_Assignment.Models;
using Repo_Pattern_Assignment.Repository;

namespace Repo_Pattern_Assignment.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoom _ser;
        private readonly IHotel _hotell;

        public RoomController(IRoom ser, IHotel hotell)
        {
            _ser = ser;
            _hotell = hotell; // Initialize _hotell
        }

        public IActionResult Index()
        {
            return View(_ser.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.HotelId = new SelectList(_hotell.getall(), "HotelId", "HotelName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomModel room)
        {
            _ser.create(room);
            return View();
        }
    }
}
