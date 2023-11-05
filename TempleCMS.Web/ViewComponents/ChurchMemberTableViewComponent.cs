using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchMemberTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ChurchMemberTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long churchId)
        {
            var members = await _context.ChurchMembers
                .Where(c => c.ChurchId == churchId && c.Role != ChurchRole.Leader)
                .Include(c => c.User)
                .ToListAsync();
            return View(members);
        }
    }
}