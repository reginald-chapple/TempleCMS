using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class PostListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public PostListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long clubId)
        {
            var posts = await _context.Posts
                .Where(p => p.ClubId == clubId)
                .Include(p => p.Author)
                .OrderByDescending(p => p.Created)
                .ToListAsync();
            return View(posts);
        }
    }
}