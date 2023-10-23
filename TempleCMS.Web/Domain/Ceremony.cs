using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Ceremony : Entity
    {
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Details { get; set; } = string.Empty;

        public CeremonyType Type { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }

        public virtual ICollection<CeremonyBooking> Bookings { get; set; } = new List<CeremonyBooking>();
    }
}