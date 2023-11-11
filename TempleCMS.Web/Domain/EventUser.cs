using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public class EventUser : Entity
    {
        public EventRole Role { get; set; }
        
        public string UserId { get; set; } = string.Empty;
        public virtual ApplicationUser? User { get; set; }

        public long EventId { get; set; }
        public virtual Event? Event { get; set; }
    }

    public enum EventRole
    {
        [Description("Steward")]
        Steward,
        [Description("Assistant")]
        Assistant,
        [Description("Attendee")]
        Attendee
    }
}