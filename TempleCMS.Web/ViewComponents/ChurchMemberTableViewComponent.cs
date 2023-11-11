using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
<<<<<<<< HEAD:TempleCMS.Web/ViewComponents/ClubMemberTableViewComponent.cs
    public class ClubMemberTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ClubMemberTableViewComponent(ApplicationDbContext context)
========
    public class ChurchMemberTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ChurchMemberTableViewComponent(ApplicationDbContext context)
>>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/ViewComponents/ChurchMemberTableViewComponent.cs
        {
            _context = context;
        }

<<<<<<<< HEAD:TempleCMS.Web/ViewComponents/ClubMemberTableViewComponent.cs
        public async Task<IViewComponentResult> InvokeAsync(long clubId)
        {
            var members = await _context.ClubMembers
                .Where(g => g.ClubId == clubId && g.Role != ClubRole.Leader)
                .Include(c => c.Member)
========
        public async Task<IViewComponentResult> InvokeAsync(long churchId)
        {
            var members = await _context.ChurchMembers
                .Where(c => c.ChurchId == churchId && c.Role != ChurchRole.Leader)
                .Include(c => c.User)
>>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/ViewComponents/ChurchMemberTableViewComponent.cs
                .ToListAsync();
            return View(members);
        }
    }
}