namespace TempleCMS.Web.Domain
{
    public class TripMember : Entity
    {
        public long MemberId { get; set; }
        public virtual Member? Member { get; set; }

        public long TripId { get; set; }
        public virtual Trip? Trip { get; set; }
    }
}