using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class ClubEventTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ClubEventTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long clubId)
        {
            var events = await _context.Events
                .Where(e => e.ClubId == clubId)
                .ToListAsync();
            return View(events);
        }
    }
}