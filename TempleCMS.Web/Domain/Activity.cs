using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Activity : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<ClubActivity> Clubs { get; set; } = new List<ClubActivity>();
    }
}