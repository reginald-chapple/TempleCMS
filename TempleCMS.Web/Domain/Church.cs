using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Domain
{
    public class Church : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Background { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Message { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Mission { get; set; } = string.Empty;

        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [PhotoExtension]
        public IFormFile? ImageUpload { get; set; }

        public long DenominationId { get; set; }
        public virtual Denomination? Denomination { get; set; }

        public virtual ICollection<Value> Values { get; set; } = new List<Value>();
        public virtual ICollection<Belief> Beliefs { get; set; } = new List<Belief>();
        public virtual ICollection<ChurchMember> Members { get; set; } = new List<ChurchMember>();
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}