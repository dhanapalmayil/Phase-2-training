using Microsoft.AspNetCore.Mvc;
using Repo_Pattern_Assignment.Models;
using Repo_Pattern_Assignment.Repository;

namespace Repo_Pattern_Assignment.Controllers
{
    public class HotelController : Controller {

        private readonly IHotel _ser;

        public HotelController(IHotel ser)
        {
            _ser = ser;
        }

        public IActionResult Index()
        {
            return View(_ser.getall());
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelModel Hotel)
        {
            _ser.create(Hotel);
            return View();
        }
    }
}
