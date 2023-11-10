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
                if (User.FindFirst("GroupId")!.Value == null)
                {
                    return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
                }

                long groupId = long.Parse(User.FindFirst("GroupId")!.Value);

                await _context.AddAsync(new GroupValue
                {
                    ValueId = value.Id,
                    GroupId = groupId
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(value);
        }
    }
}