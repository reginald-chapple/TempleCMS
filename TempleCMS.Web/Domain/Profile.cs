using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Domain
{
    public abstract class Profile : Entity
    {
        public long Id { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }

        public string AccountId { get; set; } = string.Empty;
        public virtual ApplicationUser? Account { get; set; }
    }
}