using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;

namespace TempleCMS.Web.ViewComponents
{
    public class BeliefsTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public BeliefsTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long churchId)
        {
            var beliefs = await _context.Beliefs.Where(b => b.ChurchId == churchId).ToListAsync();
            return View(beliefs);
        }
    }
}