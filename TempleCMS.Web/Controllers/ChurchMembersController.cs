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
    public class ChurchMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChurchMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChurchMembers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChurchMembers.Include(c => c.Church).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ChurchMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ChurchMembers == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMembers
                .Include(c => c.Church)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (churchMember == null)
            {
                return NotFound();
            }

            return View(churchMember);
        }

        // GET: ChurchMembers/Create
        public IActionResult Create()
        {
            ViewData["ChurchId"] = new SelectList(_context.Churches, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ChurchMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Role,UserId,ChurchId")] ChurchMember churchMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(churchMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChurchId"] = new SelectList(_context.Churches, "Id", "Id", churchMember.ChurchId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", churchMember.UserId);
            return View(churchMember);
        }

        // GET: ChurchMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ChurchMembers == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMembers.FindAsync(id);
            if (churchMember == null)
            {
                return NotFound();
            }
            ViewData["ChurchId"] = new SelectList(_context.Churches, "Id", "Id", churchMember.ChurchId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", churchMember.UserId);
            return View(churchMember);
        }

        // POST: ChurchMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Role,UserId,ChurchId")] ChurchMember churchMember)
        {
            if (id != churchMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(churchMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChurchMemberExists(churchMember.Id))
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
            ViewData["ChurchId"] = new SelectList(_context.Churches, "Id", "Id", churchMember.ChurchId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", churchMember.UserId);
            return View(churchMember);
        }

        // GET: ChurchMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ChurchMembers == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMembers
                .Include(c => c.Church)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (churchMember == null)
            {
                return NotFound();
            }

            return View(churchMember);
        }

        // POST: ChurchMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ChurchMembers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChurchMembers'  is null.");
            }
            var churchMember = await _context.ChurchMembers.FindAsync(id);
            if (churchMember != null)
            {
                _context.ChurchMembers.Remove(churchMember);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChurchMemberExists(long id)
        {
          return (_context.ChurchMembers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
