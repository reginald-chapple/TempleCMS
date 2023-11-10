using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Value : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ValueCategory Category { get; set; }

        public virtual ICollection<GroupValue> Groups { get; set; } = new List<GroupValue>();
    }

    public enum ValueCategory
    {
        Health,
        Financial,
        Relationship,
        Spiritual,
        Experiential,
        Cognitive,
        Social,
        Professional,
        Purpose,
        Environmental,
        Adaptability,
        Belonging
    }
}