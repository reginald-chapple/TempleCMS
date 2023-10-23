#nullable disable
using Microsoft.AspNetCore.Identity;

namespace TempleCMS.Web.Domain
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
