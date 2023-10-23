using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Class : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Description { get; set; } = string.Empty;

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool IsFree { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }

        public long TeacherId { get; set; }
        public virtual Clergy? Teacher { get; set; }

        public virtual ICollection<ClassStudent> Students { get; set; } = new List<ClassStudent>();
    }
}