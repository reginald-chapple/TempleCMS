using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Domain
{
    public class Image : Entity
    {
        public long Id { get; set; }

        public string FileName { get; set; } = string.Empty;

        [NotMapped]
        [PhotoExtension]
        public IFormFile? FileUpload { get; set; }

        public string User { get; set; } = string.Empty;

        public long? PostId { get; set; }
        public virtual Post? Post { get; set; }

        public long? AlbumId { get; set; }
        public virtual Album? Album { get; set; }
    }
}