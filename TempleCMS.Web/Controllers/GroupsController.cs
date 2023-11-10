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
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            return _context.Groups != null ? 
                View(await _context.Groups.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Groups'  is null.");
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,About,Mission,IsOpen,Image")] Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
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
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Groups == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Groups'  is null.");
            }
            var @group = await _context.Groups.FindAsync(id);
            if (@group != null)
            {
                _context.Groups.Remove(@group);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Route("SelectValue")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectValue(long? groupId, long[] values)
        {
            if (groupId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (groupId != long.Parse(User.FindFirst("GroupId")!.Value))
                {
                    return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
                }

                var group = await _context.Groups
                    .Include(g => g.Values)
                    .FirstOrDefaultAsync(g => g.Id == groupId);

                if (group == null)
                {
                    return NotFound();
                }

                if (values != null)
                {
                    await RemoveUnchecked(values, group);

                    foreach (var item in values)
                    {
                        if(!_context.GroupValues.Where(c => c.ValueId == item && c.GroupId == group.Id).Any())
                        {
                            group.Values.Add(new GroupValue
                            {
                                ValueId = item
                            });
                        }
                    }
                    
                    _context.Update(group);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(GroupManagerController.Values), "GroupManager", new { id = group.Id });
            }
            return RedirectToAction(nameof(GroupManagerController.Values), "GroupManager", new { id = User.FindFirst("GroupId")!.Value });
        }

        private bool GroupExists(long id)
        {
          return (_context.Groups?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task RemoveUnchecked(long[] valueIds, Group group)
        {
            var groupValues = new HashSet<long>(group.Values.Select(g => g.ValueId));
            var valueIdsList = valueIds.ToList();

            if (valueIdsList != null)
            {
                foreach (var item in groupValues)
                {
                    if (!valueIds.Contains(item))
                    {
                        var groupValue = await _context.GroupValues
                            .Where(g => g.GroupId == group.Id && g.ValueId == item)
                            .FirstOrDefaultAsync();
                        
                        if (groupValue != null)
                        {
                            _context.GroupValues.Remove(groupValue);
                            _context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
