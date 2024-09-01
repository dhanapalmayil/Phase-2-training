using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirst_Weekly_task.Models;

namespace DBFirst_Weekly_task.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly RealEstateManagementContext _context;

        public TransactionsController(RealEstateManagementContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public IActionResult Index()
        {
            var realEstateManagementContext = _context.Transactions.Include(t => t.Property).ToList();
            return View(realEstateManagementContext);
        }

        // GET: Transactions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = _context.Transactions
                .Include(t => t.Property)
                .FirstOrDefault(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyId", "PropertyId");
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TransactionId,PropertyId,ClientId,TransactionType,TransactionDate")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyId", "PropertyId", transaction.PropertyId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = _context.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyId", "PropertyId", transaction.PropertyId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TransactionId,PropertyId,ClientId,TransactionType,TransactionDate")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyId", "PropertyId", transaction.PropertyId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = _context.Transactions
                .Include(t => t.Property)
                .FirstOrDefault(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var transaction = _context.Transactions.Find(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
