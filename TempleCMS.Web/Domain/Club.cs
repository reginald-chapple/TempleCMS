using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Domain
{
    public class Club : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string About { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Guidelines { get; set; } = string.Empty;

        public bool IsOpen { get; set; } = false;

        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [PhotoExtension]
        public IFormFile? ImageUpload { get; set; }

        public virtual ICollection<ClubMember> Members { get; set; } = new List<ClubMember>();
        public virtual ICollection<ClubActivity> Activities { get; set; } = new List<ClubActivity>();

    }
}