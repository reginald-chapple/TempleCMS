#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Data
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        private readonly ApplicationDbContext _context;
        // private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserClaimsPrincipalFactory(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> options) : 
            base(userManager, roleManager, options)
        {
            _context = context;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("FullName", user.FullName));
            identity.AddClaim(new Claim("FirstName", user.FullName.Split(" ")[0]));
            identity.AddClaim(new Claim("FirstInitial", user.FullName[..1]));
            identity.AddClaim(new Claim("ProfileImage", user.ProfileImage));
            
            return identity;
        }
    }
}