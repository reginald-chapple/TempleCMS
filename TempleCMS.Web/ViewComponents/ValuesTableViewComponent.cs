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

        public async Task<IViewComponentResult> InvokeAsync(long churchId)
        {
            var values = await _context.Values.Where(b => b.ChurchId == churchId).ToListAsync();
            return View(values);
        }
    }
}