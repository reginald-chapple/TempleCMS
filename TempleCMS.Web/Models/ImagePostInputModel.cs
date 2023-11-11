using System.ComponentModel.DataAnnotations;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Models
{
    public class ImagePostInputModel
    {
        public ImagePostInputModel() {}

        [DataType(DataType.Text)]
        public string Body { get; set; } = string.Empty;

        public List<IFormFile> ImageUploads { get; set; } = new List<IFormFile>();

        [Required]
        public long ClubId { get; set; }
    }
}