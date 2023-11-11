using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class BeliefsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public BeliefsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Details")] Belief belief)
        {
            if(ModelState.IsValid)
            {
                var churchId = User.FindFirst("ChurchId")!.Value;

                if (churchId == null)
                {
                    return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
                }

                belief.ChurchId = long.Parse(churchId);

                await _context.AddAsync(belief);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ChurchManagerController.Beliefs), "ChurchManager", new { id = long.Parse(churchId) });
            }
            return View(belief);
        }
    }
}