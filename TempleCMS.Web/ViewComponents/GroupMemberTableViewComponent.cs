using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupMemberTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GroupMemberTableViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long groupId)
        {
            var members = await _context.GroupMembers
                .Where(g => g.GroupId == groupId && g.Role != GroupRole.Leader)
                .Include(c => c.Member)
                .ToListAsync();
            return View(members);
        }
    }
}