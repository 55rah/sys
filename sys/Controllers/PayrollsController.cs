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
    public class PayrollsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayrollsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Payrolls
        public async Task<IActionResult> Index()
        {
              return _context.Payroll != null ? 
                          View(await _context.Payroll.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Payroll'  is null.");
        }

        // GET: Payrolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Payroll == null)
            {
                return NotFound();
            }

            var payroll = await _context.Payroll
                .FirstOrDefaultAsync(m => m.Payroll_ID == id);
            if (payroll == null)
            {
                return NotFound();
            }

            return View(payroll);
        }

        // GET: Payrolls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payrolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Payroll_ID,Employee_ID,Salary_ID,Shift_ID,Date,TotalAmount")] Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payroll);
        }

        // GET: Payrolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Payroll == null)
            {
                return NotFound();
            }

            var payroll = await _context.Payroll.FindAsync(id);
            if (payroll == null)
            {
                return NotFound();
            }
            return View(payroll);
        }

        // POST: Payrolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Payroll_ID,Employee_ID,Salary_ID,Shift_ID,Date,TotalAmount")] Payroll payroll)
        {
            if (id != payroll.Payroll_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayrollExists(payroll.Payroll_ID))
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
            return View(payroll);
        }

        // GET: Payrolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Payroll == null)
            {
                return NotFound();
            }

            var payroll = await _context.Payroll
                .FirstOrDefaultAsync(m => m.Payroll_ID == id);
            if (payroll == null)
            {
                return NotFound();
            }

            return View(payroll);
        }

        // POST: Payrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Payroll == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Payroll'  is null.");
            }
            var payroll = await _context.Payroll.FindAsync(id);
            if (payroll != null)
            {
                _context.Payroll.Remove(payroll);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayrollExists(int id)
        {
          return (_context.Payroll?.Any(e => e.Payroll_ID == id)).GetValueOrDefault();
        }
    }
}
