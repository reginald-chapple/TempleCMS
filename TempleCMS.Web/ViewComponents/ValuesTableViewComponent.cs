using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;

namespace TempleCMS.Web.ViewComponents
{
    public class ValuesTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ValuesTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long groupId)
        {
            var values = await _context.GroupValues
                .Where(v => v.GroupId == groupId)
                .Include(v => v.Value)
                .ToListAsync();
            return View(values);
        }
    }
}