using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Data.Services;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChurchManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public ChurchManagerController(ApplicationDbContext context, IFileService fileService)
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

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            return View(church);
        }

        [Route("{id}/Edit")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
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
            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

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

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
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
            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

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
                if (church.Image != "noimage.png")
                {
                    _fileService.RemoveOldImage(church.Image, "churches");
                }

                church.Image = await _fileService.ImageUpload(model.ImageUpload!, "churches");

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

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
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
            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

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

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
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
            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

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

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
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
            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

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

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
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

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
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

            if (id != long.Parse(User.FindFirst("ChurchId")!.Value))
            {
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");
            }

            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }
            
            return View(church);
        }
    }
}