using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Domain
{
    public class Fundraiser : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Purpose { get; set; } = string.Empty;

        [Precision(8, 2)]
        public decimal Goal { get; set; } = 0.00m;

        [Precision(8, 2)]
        public decimal AmountRaised { get; set; } = 0.00m;

        public long? CommunityServiceId { get; set; }

        public long ClubId { get; set; }
        public virtual Club? Club { get; set; }

        public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
    }
}