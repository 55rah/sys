using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMS10.Models;
using sys.Areas.Identity.Data;

namespace sys.Controllers
{
    public class SalariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
              return _context.Salaries != null ? 
                          View(await _context.Salaries.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Salaries'  is null.");
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salaries == null)
            {
                return NotFound();
            }

            var salaries = await _context.Salaries
                .FirstOrDefaultAsync(m => m.Salary_ID == id);
            if (salaries == null)
            {
                return NotFound();
            }

            return View(salaries);
        }

        // GET: Salaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Salary_ID,Salary,Wage,Bonus")] Salaries salaries)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaries);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salaries == null)
            {
                return NotFound();
            }

            var salaries = await _context.Salaries.FindAsync(id);
            if (salaries == null)
            {
                return NotFound();
            }
            return View(salaries);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Salary_ID,Salary,Wage,Bonus")] Salaries salaries)
        {
            if (id != salaries.Salary_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalariesExists(salaries.Salary_ID))
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
            return View(salaries);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salaries == null)
            {
                return NotFound();
            }

            var salaries = await _context.Salaries
                .FirstOrDefaultAsync(m => m.Salary_ID == id);
            if (salaries == null)
            {
                return NotFound();
            }

            return View(salaries);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salaries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Salaries'  is null.");
            }
            var salaries = await _context.Salaries.FindAsync(id);
            if (salaries != null)
            {
                _context.Salaries.Remove(salaries);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalariesExists(int id)
        {
          return (_context.Salaries?.Any(e => e.Salary_ID == id)).GetValueOrDefault();
        }
    }
}
