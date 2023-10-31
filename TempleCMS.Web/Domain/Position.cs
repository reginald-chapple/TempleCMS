using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Position : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Responsibilities { get; set; } = string.Empty;

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }

        public virtual ICollection<UserPosition> Users { get; set; } = new List<UserPosition>();
    }
}