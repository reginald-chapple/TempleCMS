using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupEventTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GroupEventTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long groupId)
        {
            var events = await _context.Events
                .Where(e => e.GroupId == groupId)
                .ToListAsync();
            return View(events);
        }
    }
}