using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public class Denomination : Entity
    {
        public long Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public Branch Branch { get; set; }

        public virtual ICollection<Church> Churches { get; set; } = new List<Church>();
    }
}