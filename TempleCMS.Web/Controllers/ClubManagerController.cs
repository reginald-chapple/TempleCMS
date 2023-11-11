using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Data.Services;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ClubManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public ClubManagerController(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [Route("{id}")]
        public async Task<IActionResult> Index(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("{id}/Image")]
        public async Task<IActionResult> Image(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        [Route("{id}/About")]
        public async Task<IActionResult> About(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        [Route("{id}/Guidelines")]
        public async Task<IActionResult> Guidelines(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        [Route("{id}/Activities")]
        public async Task<IActionResult> Activities(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs
                .Include(g => g.Activities)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }
    }
}