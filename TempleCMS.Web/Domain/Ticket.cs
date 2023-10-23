using Microsoft.EntityFrameworkCore;

namespace TempleCMS.Web.Domain
{
    public class Ticket : Entity
    {
        public long Id { get; set; }

        public string Label { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;

        public long ObjectId { get; set; }

        public TicketType Type { get; set; }

        [Precision(8, 2)]
        public decimal Cost { get; set; } = 0.0m; 
    }
}