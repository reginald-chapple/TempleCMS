using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;

namespace TempleCMS.Web.ViewComponents
{
    public class ActivityTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ActivityTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long clubId)
        {
            var values = await _context.ClubActivities
                .Where(v => v.ClubId == clubId)
                .Include(v => v.Activity)
                .ToListAsync();
            return View(values);
        }
    }
}