namespace TempleCMS.Web.Domain
{
    public class Playlist : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public long ClubId { get; set; }
        public virtual Club? Club { get; set; }

        public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
    }
}