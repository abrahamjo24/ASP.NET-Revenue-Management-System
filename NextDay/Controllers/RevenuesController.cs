using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextDay.Data;
using NextDay.Models;

namespace NextDay.Controllers
{
    public class RevenuesController : Controller
    {
        private readonly NextDayContext _context;

        public RevenuesController(NextDayContext context)
        {
            _context = context;
        }

        // GET: Revenues
        public async Task<IActionResult> Index()
        {
              return View(await _context.Revenue.ToListAsync());
        }

        // GET: Revenues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Revenue == null)
            {
                return NotFound();
            }

            var revenue = await _context.Revenue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revenue == null)
            {
                return NotFound();
            }

            return View(revenue);
        }

        // GET: Revenues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Revenues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Source,CreatedDate,Owner,Amount")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revenue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(revenue);
        }

        // GET: Revenues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Revenue == null)
            {
                return NotFound();
            }

            var revenue = await _context.Revenue.FindAsync(id);
            if (revenue == null)
            {
                return NotFound();
            }
            return View(revenue);
        }

        // POST: Revenues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Source,CreatedDate,Owner,Amount")] Revenue revenue)
        {
            if (id != revenue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revenue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevenueExists(revenue.Id))
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
            return View(revenue);
        }

        // GET: Revenues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Revenue == null)
            {
                return NotFound();
            }

            var revenue = await _context.Revenue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revenue == null)
            {
                return NotFound();
            }

            return View(revenue);
        }

        // POST: Revenues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Revenue == null)
            {
                return Problem("Entity set 'NextDayContext.Revenue'  is null.");
            }
            var revenue = await _context.Revenue.FindAsync(id);
            if (revenue != null)
            {
                _context.Revenue.Remove(revenue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevenueExists(int id)
        {
          return _context.Revenue.Any(e => e.Id == id);
        }
    }
}
