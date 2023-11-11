using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ValuesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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
        public async Task<IActionResult> Create([Bind("Id,Name,Details")] Value value)
        {
            if(ModelState.IsValid)
            {
                var churchId = User.FindFirst("ChurchId")!.Value;

                if (churchId == null)
                {
                    return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
                }

                value.ChurchId = long.Parse(churchId);

                await _context.AddAsync(value);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ChurchManagerController.Values), "ChurchManager", new { id = long.Parse(churchId) });
            }
            return View(value);
        }
    }
}