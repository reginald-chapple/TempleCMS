using TempleCMS.Web.Infrastructure.Validation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempleCMS.Web.Domain
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string FullName { get; set; } = string.Empty;
        
        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [FileExtension]
        public IFormFile? ImageUpload { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Parse("1/1/1901");

        public virtual ChurchMember? Church { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
        public virtual ICollection<UserNotification> Notifications { get; set; } = new List<UserNotification>();
        public virtual ICollection<ChatUser> Chats { get; set; } = new List<ChatUser>();
        public virtual ICollection<EventUser> Events { get; set; } = new List<EventUser>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
