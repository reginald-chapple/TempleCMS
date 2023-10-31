using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Event : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Details { get; set; } = string.Empty;

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool IsFree { get; set; }

        public EventType Type { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }

        public virtual ICollection<EventUser> Users { get; set; } = new List<EventUser>();
    }

    public enum EventType
    {
        [Description("Booking")]
        Booking,
        [Description("Ceremony")]
        Ceremony,
        [Description("Class")]
        Class,
        [Description("Conference")]
        Conference,
        [Description("Liturgy")]
        Liturgy,
        [Description("Trip")]
        Trip
    }
}