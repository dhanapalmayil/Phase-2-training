using Assessment_SocialMedia.Models;
using Assessment_SocialMedia.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assessment_SocialMedia.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _ser;
        private readonly IUser _userser;

        public PostController(IPost ser,IUser userser)
        {
            _ser = ser;
            _userser = userser;
        }
        public ActionResult Index()
        {
            return View(_ser.getall());
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View(_ser.details(id));
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(_userser.getall(), "Uid", "UserName");
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            try
            {
                _ser.create(post);
                ViewBag.UserId = new SelectList(_userser.getall(), "Uid", "UserName");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.UserId = new SelectList(_userser.getall(), "Uid", "UserName");
            return View(_ser.details(id));
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            try
            {
                ViewBag.UserId = new SelectList(_userser.getall(), "Uid", "UserName");
                _ser.edit(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ser.details(id));
        }

        // POST: PostController/Delete/5
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
