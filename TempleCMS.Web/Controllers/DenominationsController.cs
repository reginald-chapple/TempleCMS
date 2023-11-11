using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Controllers
{
    public class DenominationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DenominationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Denominations
        public async Task<IActionResult> Index()
        {
              return _context.Denominations != null ? 
                          View(await _context.Denominations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Denominations'  is null.");
        }

        // GET: Denominations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Denominations == null)
            {
                return NotFound();
            }

            var denomination = await _context.Denominations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denomination == null)
            {
                return NotFound();
            }

            return View(denomination);
        }

        // GET: Denominations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Denominations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Branch")] Denomination denomination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denomination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(denomination);
        }

        // GET: Denominations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Denominations == null)
            {
                return NotFound();
            }

            var denomination = await _context.Denominations.FindAsync(id);
            if (denomination == null)
            {
                return NotFound();
            }
            return View(denomination);
        }

        // POST: Denominations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Branch")] Denomination denomination)
        {
            if (id != denomination.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denomination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenominationExists(denomination.Id))
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
            return View(denomination);
        }

        // GET: Denominations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Denominations == null)
            {
                return NotFound();
            }

            var denomination = await _context.Denominations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denomination == null)
            {
                return NotFound();
            }

            return View(denomination);
        }

        // POST: Denominations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Denominations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Denominations'  is null.");
            }
            var denomination = await _context.Denominations.FindAsync(id);
            if (denomination != null)
            {
                _context.Denominations.Remove(denomination);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenominationExists(long id)
        {
          return (_context.Denominations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
