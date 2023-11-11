using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Models
{
    public class ClubImageEditModel
    {
        public long Id { get; set; }
        
        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [PhotoExtension]
        public IFormFile? ImageUpload { get; set; }
    }
}