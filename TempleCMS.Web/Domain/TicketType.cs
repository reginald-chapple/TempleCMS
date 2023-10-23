using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public enum TicketType
    {
        [Description("Conference")]
        Conference,
        [Description("Class")]
        Class,
        [Description("Trip")]
        Trip
    }
}