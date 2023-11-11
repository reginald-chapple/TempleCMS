using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public class ClubMember : Entity
    {
        public long Id { get; set; }
        public ClubRole Role { get; set; }
        
        public string MemberId { get; set; } = string.Empty;
        public virtual ApplicationUser? Member { get; set; }

        public long ClubId { get; set; }
        public virtual Club? Club { get; set; }
    }

    public enum ClubRole
    {
        [Description("Leader")]
        Leader,
        [Description("Member")]
        Member
    }
}