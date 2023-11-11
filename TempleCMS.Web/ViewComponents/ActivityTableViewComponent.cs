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

<<<<<<< HEAD:TempleCMS.Web/ViewComponents/ActivityTableViewComponent.cs
        public async Task<IViewComponentResult> InvokeAsync(long clubId)
        {
            var values = await _context.ClubActivities
                .Where(v => v.ClubId == clubId)
                .Include(v => v.Activity)
                .ToListAsync();
=======
        public async Task<IViewComponentResult> InvokeAsync(long churchId)
        {
            var values = await _context.Values.Where(b => b.ChurchId == churchId).ToListAsync();
>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/ViewComponents/ValuesTableViewComponent.cs
            return View(values);
        }
    }
}