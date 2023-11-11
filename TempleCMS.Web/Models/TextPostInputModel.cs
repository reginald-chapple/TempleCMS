using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
    public class TextPostInputModel
    {
        [DataType(DataType.Text)]
        public string Body { get; set; } = string.Empty;

        [Required]
        public long ClubId { get; set; }
    }
}