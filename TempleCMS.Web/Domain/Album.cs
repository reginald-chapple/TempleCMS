namespace TempleCMS.Web.Domain
{
    public class Album : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}