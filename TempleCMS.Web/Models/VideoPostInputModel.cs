using System.ComponentModel.DataAnnotations;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Models
{
    public class VideoPostInputModel
    {
        public VideoPostInputModel() {}

        [DataType(DataType.Text)]
        public string Body { get; set; } = string.Empty;

        [Required]
        public IFormFile? VideoUpload { get; set; }

        [Required]
        public long ClubId { get; set; }
    }
}