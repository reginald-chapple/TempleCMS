using System;

namespace TempleCMS.Web.Domain
{
    public class UserPosition : Entity
    {
        public string UserId { get; set; } = string.Empty;
        public virtual ApplicationUser? User { get; set; }

        public long PositionId { get; set; }
        public virtual Position? Position { get; set; }
    }
}
