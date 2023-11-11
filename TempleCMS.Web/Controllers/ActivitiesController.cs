using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ActivitiesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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
        public async Task<IActionResult> Create([Bind("Id,Name,Details")] Activity activity)
        {
            if(ModelState.IsValid)
            {
<<<<<<< HEAD:TempleCMS.Web/Controllers/ActivitiesController.cs
                await _context.AddAsync(activity);
=======
                var churchId = User.FindFirst("ChurchId")!.Value;

                if (churchId == null)
                {
                    return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
                }

                value.ChurchId = long.Parse(churchId);

                await _context.AddAsync(value);
>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/Controllers/ValuesController.cs
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ChurchesController.Values), "Churches", new { id = long.Parse(churchId) });
            }
            return View(activity);
        }
    }
}