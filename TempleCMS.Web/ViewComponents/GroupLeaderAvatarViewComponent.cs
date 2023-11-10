using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupLeaderAvatarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GroupLeaderAvatarViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long groupId)
        {
            var user = await _context.GroupMembers
                .Where(g => g.GroupId == groupId && g.Role == GroupRole.Leader)
                .Include(g => g.Member)
                .Select(g => g.Member)
                .FirstAsync();
            return View(user);
        }
    }
}