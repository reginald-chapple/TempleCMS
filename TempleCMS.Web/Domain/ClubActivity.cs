using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public class ClubActivity : Entity
    {   
        public long ActivityId { get; set; }
        public virtual Activity? Activity { get; set; }

        public long ClubId { get; set; }
        public virtual Club? Club { get; set; }
    }
}