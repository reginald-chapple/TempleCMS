namespace TempleCMS.Web.Domain
{
    public class ClassStudent : Entity
    {
        public long StudentId { get; set; }
        public virtual Member? Student { get; set; }

        public long ClassId { get; set; }
        public virtual Class? Class { get; set; }
    }
}