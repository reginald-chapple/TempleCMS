using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TempleCMS.Web.Controllers
{

    // [Authorize(Roles = "admin")]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
            return View(users);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            var user = new ApplicationUser();
            user.UserRoles = new List<ApplicationUserRole>();
            PopulateAssignedRoleData(user);
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserInputModel model, string[] selectedRoles)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                FullName = model.FullName,
                UserName = model.Email,
                Email = model.Email
            };

            if (ModelState.IsValid)
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/members");
                string imageName = Guid.NewGuid().ToString() + "_" + model.ImageUpload!.FileName;
                string filePath = Path.Combine(uploadsDir, imageName);

                FileStream fs = new FileStream(filePath, FileMode.Create);
                await model.ImageUpload.CopyToAsync(fs);
                fs.Close();

                user.Image = imageName;

                if (selectedRoles != null)
                {
                    user.UserRoles = new List<ApplicationUserRole>();
                    foreach (var role in selectedRoles)
                    {
                        var roleToAdd = new ApplicationUserRole { UserId = user.Id, RoleId = role };
                        user.UserRoles.Add(roleToAdd);
                    }
                }
                await _userManager.CreateAsync(user, model.Password);
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedRoleData(user);
            return View(model);
        }

        private void PopulateAssignedRoleData(ApplicationUser user)
        {
            var allRoles = _roleManager.Roles.ToList();
            var userRoles = new HashSet<string>(user.UserRoles.Select(t => t.RoleId));
            var viewModel = new List<AssignedRole>();

            foreach (var role in allRoles)
            {
                viewModel.Add(new AssignedRole
                {
                    RoleId = role.Id,
                    Name = role.Name!,
                    Assigned = userRoles.Contains(role.Id)
                });
            }
            ViewData["Roles"] = viewModel;
        }
    }
}