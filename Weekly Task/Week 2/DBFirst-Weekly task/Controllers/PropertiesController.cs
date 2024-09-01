using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirst_Weekly_task.Models;

namespace DBFirst_Weekly_task.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly RealEstateManagementContext _context;

        public PropertiesController(RealEstateManagementContext context)
        {
            _context = context;
        }

        // GET: Properties
        public IActionResult Index()
        {
            var properties = _context.Properties.ToList();
            return View(properties);
        }

        // GET: Properties/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = _context.Properties
                .FirstOrDefault(m => m.PropertyId == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PropertyId,Title,Description,Price,Address,City,State,ZipCode,ImagePath,Status")] Property property)
        {
            if (ModelState.IsValid)
            {
                _context.Add(property);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        // GET: Properties/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = _context.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }

        // POST: Properties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PropertyId,Title,Description,Price,Address,City,State,ZipCode,ImagePath,Status")] Property property)
        {
            if (id != property.PropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(property);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(property.PropertyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        // GET: Properties/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = _context.Properties
                .FirstOrDefault(m => m.PropertyId == id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var property = _context.Properties.Find(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.PropertyId == id);
        }
    }
}
