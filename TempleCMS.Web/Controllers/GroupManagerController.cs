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
    public class GroupManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public GroupManagerController(ApplicationDbContext context, IFileService fileService)
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

            if (id != long.Parse(User.FindFirst("GroupId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

            var group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [Route("{id}/Image")]
        public async Task<IActionResult> Image(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != long.Parse(User.FindFirst("GroupId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

            var group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [Route("{id}/About")]
        public async Task<IActionResult> About(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != long.Parse(User.FindFirst("GroupId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

            var group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [Route("{id}/Mission")]
        public async Task<IActionResult> Mission(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != long.Parse(User.FindFirst("GroupId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

            var group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [Route("{id}/Values")]
        public async Task<IActionResult> Values(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != long.Parse(User.FindFirst("GroupId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

            var group = await _context.Groups
                .Include(g => g.Values)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }
    }
}