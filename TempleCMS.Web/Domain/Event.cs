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

        public string Location { get; set; } = string.Empty;

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool IsFree { get; set; }

        public EventCategory Category { get; set; }

        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }

        public virtual ICollection<EventUser> Users { get; set; } = new List<EventUser>();
    }

    public enum EventCategory
    {
        [Description("Campaign")]
        Campaign,
        [Description("Celebration")]
        Celebration,
        [Description("Entertainment")]
        Entertainment,
        [Description("Food and Beverage")]
        FoodBeverage,
        [Description("Meetup")]
        Meetup,
        [Description("Trip")]
        Trip
    }
}