using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class ClubLeaderAvatarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ClubLeaderAvatarViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long clubId)
        {
            var user = await _context.ClubMembers
                .Where(g => g.ClubId == clubId && g.Role == ClubRole.Leader)
                .Include(g => g.Member)
                .Select(g => g.Member)
                .FirstAsync();
            return View(user);
        }
    }
}