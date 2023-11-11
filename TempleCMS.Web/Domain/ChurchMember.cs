using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public class ChurchMember : Entity
    {
        public long Id { get; set; }
        public ChurchRole Role { get; set; }
        
        public string UserId { get; set; } = string.Empty;
        public virtual ApplicationUser? User { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }
    }

    public enum ChurchRole
    {
        [Description("Leader")]
        Leader,
        [Description("Clergy")]
        Clergy,
        [Description("Laity")]
        Laity
    }
}