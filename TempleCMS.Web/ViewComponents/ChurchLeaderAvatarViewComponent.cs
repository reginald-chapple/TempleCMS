using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchLeaderAvatarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ChurchLeaderAvatarViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long churchId)
        {
            var user = await _context.ChurchMembers
                .Where(g => g.ChurchId == churchId && g.Role == ChurchRole.Leader)
                .Include(g => g.User)
                .Select(g => g.User)
                .FirstAsync();
            return View(user);
        }
    }
}