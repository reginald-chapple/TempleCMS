using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;
using TempleCMS.Web.Infrastructure.Helpers;
using TempleCMS.Web.Data.Services;

namespace TempleCMS.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IFileService _fileService;

        public AccountController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IFileService fileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _fileService = fileService;
        }

        [TempData]
        public string ErrorMessage { get; set; } = string.Empty;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserInputModel user, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                ApplicationUser newUser = new ApplicationUser 
                { 
                    Id = Guid.NewGuid().ToString(),
                    FullName = user.FullName,
                    UserName = user.UserName, 
                    Email = user.Email,
                    Image = await _fileService.ImageUpload(user.ImageUpload!, "members")
                };

                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    var group = new Group
                    {
                        Name = "Unnamed",
                    };
                    group.Members.Add(new GroupMember { MemberId = newUser.Id, Role = GroupRole.Leader });
                    
                    await _context.Groups.AddAsync(group);
                    await _context.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(newUser, "Member");
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToLocal(returnUrl!);
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null) 
        {

            ViewData["ReturnUrl"] = returnUrl;

            // Clear the existing external cookie to ensure a clean login process
            await _signInManager.SignOutAsync();


            return View(new AuthenticationModel());
        } 

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthenticationModel loginVM, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl!);
                }

                if (result.IsLockedOut)
                {
                    return RedirectToAction(nameof(Lockout));
                }

                ModelState.AddModelError("", "Invalid email or password");
            }

            return View(loginVM);
        }

        [HttpGet]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();

            return Redirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion

    }
}
