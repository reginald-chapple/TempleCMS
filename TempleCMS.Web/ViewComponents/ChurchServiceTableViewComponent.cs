using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchServiceTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ChurchServiceTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long churchId)
        {
            var services = await _context.Services
                .Where(c => c.ChurchId == churchId)
                .ToListAsync();
            return View(services);
        }
    }
}