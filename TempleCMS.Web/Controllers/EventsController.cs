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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
            var applicationDbContext = _context.Events.Include(e => e.Club);
=======
            var applicationDbContext = _context.Event.Include(e => e.Church);
>>>>>>> parent of 5530561 (massive changes)
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var @event = await _context.Events
                .Include(e => e.Club)
=======
            var @event = await _context.Event
                .Include(e => e.Church)
>>>>>>> parent of 5530561 (massive changes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["ChurchId"] = new SelectList(_context.Churches, "Id", "Id");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Details,StartTime,EndTime,IsFree,Type,ChurchId")] Event @event)
        {
            if (ModelState.IsValid)
            {
<<<<<<< HEAD
                long clubId = long.Parse(User.FindFirst("ClubId")!.Value);
                @event.ClubId = clubId;
=======
>>>>>>> parent of 5530561 (massive changes)
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChurchId"] = new SelectList(_context.Churches, "Id", "Id", @event.ChurchId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["ChurchId"] = new SelectList(_context.Churches, "Id", "Id", @event.ChurchId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Details,StartTime,EndTime,IsFree,Type,ChurchId")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

<<<<<<< HEAD
            if (User.FindFirst("ClubId")!.Value == null)
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

            long clubId = long.Parse(User.FindFirst("ClubId")!.Value);

=======
>>>>>>> parent of 5530561 (massive changes)
            if (ModelState.IsValid)
            {
                try
                {
<<<<<<< HEAD
                    @event.ClubId = clubId;
=======
>>>>>>> parent of 5530561 (massive changes)
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            ViewData["ChurchId"] = new SelectList(_context.Churches, "Id", "Id", @event.ChurchId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var @event = await _context.Events
                .Include(e => e.Club)
=======
            var @event = await _context.Event
                .Include(e => e.Church)
>>>>>>> parent of 5530561 (massive changes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Event == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Event'  is null.");
            }
            var @event = await _context.Event.FindAsync(id);
            if (@event != null)
            {
                _context.Event.Remove(@event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(long id)
        {
          return (_context.Event?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
