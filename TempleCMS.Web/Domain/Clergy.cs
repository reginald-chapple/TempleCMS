namespace TempleCMS.Web.Domain
{
    public class Clergy : Profile
    {
        public virtual ICollection<Sermon> Sermons { get; set; } = new List<Sermon>();
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
        public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}