using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Value : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Details { get; set; } = string.Empty;

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }
    }
}