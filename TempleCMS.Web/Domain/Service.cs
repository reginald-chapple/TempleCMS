using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public class Service : Entity
    {
        public long Id { get; set; }

        public ServiceType Type { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

    public enum ServiceType
    {
        [Description("Anointing of the Sick")]
        AnointingOfTheSick,
        [Description("Funeral")]
        Funeral,
        [Description("Marriage")]
        Marriage,
        [Description("Counseling")]
        Counseling,
        [Description("Reconciliation")]
        Reconciliation,
        [Description("Exorcism")]
        Exorcism,
        [Description("Christening")]
        Christening 
    }
}