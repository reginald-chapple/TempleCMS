using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
<<<<<<<< HEAD:TempleCMS.Web/ViewComponents/ClubEventTableViewComponent.cs
    public class ClubEventTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ClubEventTableViewComponent(ApplicationDbContext context)
========
    public class ChurchServiceTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ChurchServiceTableViewComponent(ApplicationDbContext context)
>>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/ViewComponents/ChurchServiceTableViewComponent.cs
        {
            _context = context;
        }

<<<<<<<< HEAD:TempleCMS.Web/ViewComponents/ClubEventTableViewComponent.cs
        public async Task<IViewComponentResult> InvokeAsync(long clubId)
        {
            var events = await _context.Events
                .Where(e => e.ClubId == clubId)
========
        public async Task<IViewComponentResult> InvokeAsync(long churchId)
        {
            var services = await _context.Services
                .Where(c => c.ChurchId == churchId)
>>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/ViewComponents/ChurchServiceTableViewComponent.cs
                .ToListAsync();
            return View(services);
        }
    }
}