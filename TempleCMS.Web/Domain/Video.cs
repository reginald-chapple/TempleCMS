using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Domain
{
    public class Video : Entity
    {
        public long Id { get; set; }

        public string FileName { get; set; } = string.Empty;

        [NotMapped]
        [VideoExtension]
        public IFormFile? FileUpload { get; set; }

        public string User { get; set; } = string.Empty;

        public long? PostId { get; set; }
        public virtual Post? Post { get; set; }

        public long? PlaylistId { get; set; }
        public virtual Playlist? Playlist { get; set; }

    }
}