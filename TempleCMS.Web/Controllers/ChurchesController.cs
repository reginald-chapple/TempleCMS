using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    public class ChurchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ChurchesController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Churches.Include(c => c.Denomination).ToListAsync());
        }

        [Route("All")]
        public async Task<IActionResult> All()
        {
            return View(await _context.Churches.ToListAsync());
        }

        [Route("Create")]
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

        [Route("{id}/Office")]
        public async Task<IActionResult> Office(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
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

        [Route("{id}/Edit")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            ViewData["Denominations"] = await _context.Denominations.ToListAsync();
            
            return View(church);
        }

        [Route("{id}/Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ChurchEditModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                church.Name = model.Name;
                church.DenominationId = model.DenominationId;

                _context.Update(church);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Edit), "Churches", new { id = church.Id });
            }

            return View(model);
        }

        [Route("{id}/Image")]
        public async Task<IActionResult> Image(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }

        [Route("{id}/Image")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Image(long id, ChurchImageEditModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/churches");
                string imageName = Guid.NewGuid().ToString() + "_" + model.ImageUpload!.FileName;
                string filePath = Path.Combine(uploadsDir, imageName);
                
                FileStream fs = new FileStream(filePath, FileMode.Create);
                await model.ImageUpload.CopyToAsync(fs);
                fs.Close();

                if (church.Image != "noimage.png")
                {
                    string oldImage = Path.Combine(uploadsDir, church.Image);
                    System.IO.File.Delete(oldImage);
                }

                church.Image = imageName;

                _context.Update(church);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Image), "Churches", new { id = church.Id });
            }

            return View(model);
        }

        [Route("{id}/Background")]
        public async Task<IActionResult> Background(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }

        [Route("{id}/Background")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Background(long id, ChurchBackgroundEditModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                church.Background = HttpUtility.HtmlEncode(model.Background);

                _context.Update(church);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Background), "Churches", new { id = church.Id });
            }

            return View(model);
        }

        [Route("{id}/Message")]
        public async Task<IActionResult> Message(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }

        [Route("{id}/Message")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Message(long id, ChurchMessageEditModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                church.Message = HttpUtility.HtmlEncode(model.Message);

                _context.Update(church);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Message), "Churches", new { id = church.Id });
            }

            return View(model);
        }

        [Route("{id}/Mission")]
        public async Task<IActionResult> Mission(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }

        [Route("{id}/Mission")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Mission(long id, ChurchMissionEditModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                church.Mission = HttpUtility.HtmlEncode(model.Mission);

                _context.Update(church);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Mission), "Churches", new { id = church.Id });
            }

            return View(model);
        }

        [Route("{id}/Beliefs")]
        public async Task<IActionResult> Beliefs(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }

        [Route("{id}/Values")]
        public async Task<IActionResult> Values(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }

        [Route("{id}/Members")]
        public async Task<IActionResult> Members(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }

        [Route("{id}/Services")]
        public async Task<IActionResult> Services(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }
    
        [Route("{branch}/GetDenominations")]
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