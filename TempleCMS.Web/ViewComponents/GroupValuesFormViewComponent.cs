using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupValuesFormViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GroupValuesFormViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Values.ToListAsync();
            var valuesList = values.GroupBy(v => v.Category).ToList();
            return View(valuesList);
        }
    }
}