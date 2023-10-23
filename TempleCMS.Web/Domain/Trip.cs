using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TempleCMS.Web.Domain
{
    public class Trip : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Description { get; set; } = string.Empty;

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
        
        public string Destination { get; set; } = string.Empty;

        public bool IsFree { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }

        public long OrganizerId { get; set; }
        public virtual Clergy? Organizer { get; set; }

        public virtual ICollection<TripMember> Members { get; set; } = new List<TripMember>();
    }
}