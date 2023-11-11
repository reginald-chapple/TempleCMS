using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ClubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clubs
        public async Task<IActionResult> Index()
        {
            return _context.Clubs != null ? 
                View(await _context.Clubs.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Clubs'  is null.");
        }

        

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Clubs == null)
            {
                return NotFound();
            }

            var @club = await _context.Clubs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@club == null)
            {
                return NotFound();
            }

            return View(@club);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Clubs == null)
            {
                return NotFound();
            }

            var @club = await _context.Clubs.FindAsync(id);
            if (@club == null)
            {
                return NotFound();
            }
            return View(@club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,About,Guidelines,IsOpen,Image")] Club @club)
        {
            if (id != @club.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@club);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubExists(@club.Id))
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
            return View(@club);
        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Clubs == null)
            {
                return NotFound();
            }

            var @club = await _context.Clubs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@club == null)
            {
                return NotFound();
            }

            return View(@club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Clubs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clubs'  is null.");
            }
            var @club = await _context.Clubs.FindAsync(id);
            if (@club != null)
            {
                _context.Clubs.Remove(@club);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Route("SelectActivity")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectActivity(long? clubId, long[] activities)
        {
            if (clubId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var club = await _context.Clubs
                    .Include(g => g.Activities)
                    .FirstOrDefaultAsync(g => g.Id == clubId);

                if (club == null)
                {
                    return NotFound();
                }

                if (activities != null)
                {
                    await RemoveUnchecked(activities, club);

                    foreach (var item in activities)
                    {
                        if(!_context.ClubActivities.Where(c => c.ActivityId == item && c.ClubId == club.Id).Any())
                        {
                            club.Activities.Add(new ClubActivity
                            {
                                ActivityId = item
                            });
                        }
                    }
                    
                    _context.Update(club);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(DashboardController.Index), "Dashboard", new { id = User.FindFirst(ClaimTypes.NameIdentifier)!.Value });
            }
            return RedirectToAction(nameof(DashboardController.Index), "Dashboard", new { id = User.FindFirst(ClaimTypes.NameIdentifier)!.Value });
        }

        private bool ClubExists(long id)
        {
          return (_context.Clubs?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task RemoveUnchecked(long[] valueIds, Club club)
        {
            var clubValues = new HashSet<long>(club.Activities.Select(g => g.ActivityId));
            var valueIdsList = valueIds.ToList();

            if (valueIdsList != null)
            {
                foreach (var item in clubValues)
                {
                    if (!valueIds.Contains(item))
                    {
                        var clubActivity = await _context.ClubActivities
                            .Where(g => g.ClubId == club.Id && g.ActivityId == item)
                            .FirstOrDefaultAsync();
                        
                        if (clubActivity != null)
                        {
                            _context.ClubActivities.Remove(clubActivity);
                            _context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
