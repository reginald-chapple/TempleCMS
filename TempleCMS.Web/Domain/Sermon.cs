using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Sermon : Entity
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Body { get; set; } = string.Empty;

        public long ClergyId { get; set; }
        public virtual Clergy? Clergy { get; set; }
    }
}