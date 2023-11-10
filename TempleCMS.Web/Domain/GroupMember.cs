using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public class GroupMember : Entity
    {
        public long Id { get; set; }
        public GroupRole Role { get; set; }
        
        public string MemberId { get; set; } = string.Empty;
        public virtual ApplicationUser? Member { get; set; }

        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }
    }

    public enum GroupRole
    {
        [Description("Leader")]
        Leader,
        [Description("Member")]
        Member
    }
}