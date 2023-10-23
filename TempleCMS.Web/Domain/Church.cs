using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Domain
{
    public class Church : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Background { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Message { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Mission { get; set; } = string.Empty;

        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [FileExtension]
        public IFormFile? ImageUpload { get; set; }

        public long LeaderId { get; set; }
        public virtual Clergy? Leader { get; set; }

        public virtual ICollection<Value> Values { get; set; } = new List<Value>();
        public virtual ICollection<Belief> Beliefs { get; set; } = new List<Belief>();
        public virtual ICollection<Clergy> Clergies { get; set; } = new List<Clergy>();
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
        public virtual ICollection<WorshipService> WorshipServices { get; set; } = new List<WorshipService>();
        public virtual ICollection<Conference> Conferences { get; set; } = new List<Conference>();
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>(); 
        public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
        public virtual ICollection<Ceremony> Ceremonies { get; set; } = new List<Ceremony>();
    }
}