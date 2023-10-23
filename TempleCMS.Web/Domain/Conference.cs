using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Domain
{
    public class Conference : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Description { get; set; } = string.Empty;

        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [FileExtension]
        public IFormFile? ImageUpload { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool IsFree { get; set; }

        public long ChurchId { get; set; }
        public virtual Church? Church { get; set; }
    }
}