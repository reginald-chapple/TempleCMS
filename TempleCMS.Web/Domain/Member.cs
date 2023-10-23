namespace TempleCMS.Web.Domain
{
    public class Member : Profile
    {
        public virtual ICollection<ClassStudent> Classes { get; set; } = new List<ClassStudent>();
        public virtual ICollection<TripMember> Trips { get; set; } = new List<TripMember>();
    }
}