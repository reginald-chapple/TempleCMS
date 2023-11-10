using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Domain
{
    public class Group : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string About { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Mission { get; set; } = string.Empty;

        public bool IsOpen { get; set; } = false;

        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [PhotoExtension]
        public IFormFile? ImageUpload { get; set; }

        public virtual ICollection<GroupMember> Members { get; set; } = new List<GroupMember>();
        public virtual ICollection<GroupValue> Values { get; set; } = new List<GroupValue>();

    }
}