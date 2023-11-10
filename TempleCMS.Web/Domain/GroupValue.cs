using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public class GroupValue : Entity
    {   
        public long ValueId { get; set; }
        public virtual Value? Value { get; set; }

        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }
    }
}