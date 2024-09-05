using Assessment_SocialMedia.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assessment_SocialMedia.Models;
using Assessment_SocialMedia.Services;

namespace Assessment_SocialMedia.Controllers
{
    public class UserController : Controller
    {

        private readonly IUser _ser;

        public UserController(IUser ser)
        {
            _ser = ser;
        }


        // GET: UserController
        public ActionResult Index()
        {
            return View(_ser.getall());

        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View(_ser.details(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {

            
            try
            {
                _ser.create(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_ser.details(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                _ser.edit(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ser.details(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _ser.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
