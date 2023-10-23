using System.ComponentModel.DataAnnotations;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Domain
{
    public class CeremonyBooking : Entity
    {
        public long Id { get; set; }

        public string Details { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Date{ get; set; } = DateTime.Parse("1/1/1901");

        public bool IsCancelled { get; set; } = false;

        public bool IsAccepted { get; set; } = false;

        public long CeremonyId { get; set; }
        public virtual Ceremony? Ceremony { get; set; }

        public long MemberId { get; set; }
        public virtual Member? Member { get; set; }
    }
}