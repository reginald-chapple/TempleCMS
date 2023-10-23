using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class WorshipService : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Description { get; set; } = string.Empty;

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }
    }
}