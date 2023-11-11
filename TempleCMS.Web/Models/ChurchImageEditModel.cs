using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Models
{
<<<<<<<< HEAD:TempleCMS.Web/Models/ClubImageEditModel.cs
    public class ClubImageEditModel
========
    public class ChurchImageEditModel
>>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/Models/ChurchImageEditModel.cs
    {
        public long Id { get; set; }
        
        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [FileExtension]
        public IFormFile? ImageUpload { get; set; }
    }
}