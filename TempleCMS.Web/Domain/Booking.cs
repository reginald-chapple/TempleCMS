using System.ComponentModel.DataAnnotations;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Domain
{
    public class Booking : Entity
    {
        public long Id { get; set; }

        public string Details { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DateDesired { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateBooked { get; set; }

        public bool IsCancelled { get; set; } = false;

        public bool IsAccepted { get; set; } = false;

        public long ServiceId { get; set; }
        public virtual Service? Service { get; set; }

        public string UserId { get; set; } = string.Empty;
        public virtual ApplicationUser? User { get; set; }
    }
}