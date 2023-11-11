using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Data.Services;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChurchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IFileService _fileService;

        public ChurchesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IFileService fileService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _fileService = fileService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Churches.Include(c => c.Denomination).ToListAsync());
        }

        [Route("All")]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View(await _context.Churches.ToListAsync());
        }

        [Route("Create")]
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChurchInputModel model)
        {
            if(ModelState.IsValid)
            {
                var church = new Church
                {
                    Name = model.ChurchName,
                    DenominationId = model.DenominationId
                };

                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = model.FullName,
                    UserName = model.Email, 
                    Email = model.Email
                };

                _context.Add(church);
                _context.SaveChanges();

                await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "Leadership");

                await _context.ChurchMembers.AddAsync(new ChurchMember
                {
                    Role = ChurchRole.Leader,
                    ChurchId = church.Id,
                    UserId = user.Id
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(All));
            }
            return View(model);
        }

        [Route("{id}/Details")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches
                .Include(c => c.Denomination)
                .Include(c => c.Members)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }

        [Route("{id}/Join")]
        public async Task<IActionResult> Join(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches
                .Include(c => c.Denomination)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (church == null)
            {
                return NotFound();
            }

            await _context.AddAsync(new ChurchMember
            {
                Role = ChurchRole.Laity,
                ChurchId = church.Id,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            });
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Details), new { id = church.Id });
        }
    
        [Route("{branch}/GetDenominations")]
        [AllowAnonymous]
        public async Task<JsonResult> GetDenominations(int branch)
        {
            return branch switch
            {
                0 => new JsonResult(await _context.Denominations
                                        .Where(d => d.Branch == Branch.Catholic).ToListAsync()),
                1 => new JsonResult(await _context.Denominations
                                        .Where(d => d.Branch == Branch.EasternOrthodox).ToListAsync()),
                2 => new JsonResult(await _context.Denominations
                                        .Where(d => d.Branch == Branch.OrientalOrthodox).ToListAsync()),
                3 => new JsonResult(await _context.Denominations
                                        .Where(d => d.Branch == Branch.Protestant).ToListAsync()),
                4 => new JsonResult(await _context.Denominations
                                        .Where(d => d.Branch == Branch.Unitarian).ToListAsync()),
                5 => new JsonResult(await _context.Denominations
                                        .Where(d => d.Branch == Branch.NonDenominational).ToListAsync()),
                _ => new JsonResult(new List<Denomination>().AsReadOnly()),
            };
        }

       private bool ChurchExists(long id)
    {
        return (_context.Churches?.Any(e => e.Id == id)).GetValueOrDefault();
    } 
    }
}