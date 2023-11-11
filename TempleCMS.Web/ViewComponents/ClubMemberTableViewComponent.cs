using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class ClubMemberTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ClubMemberTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long clubId)
        {
            var members = await _context.ClubMembers
                .Where(g => g.ClubId == clubId && g.Role != ClubRole.Leader)
                .Include(c => c.Member)
                .ToListAsync();
            return View(members);
        }
    }
}