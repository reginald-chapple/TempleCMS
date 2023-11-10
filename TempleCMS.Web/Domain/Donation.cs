using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Domain
{
    public class Donation : Entity
    {
        public Donation() {}
        
        public long Id { get; set; }
        
        [Precision(8, 2)]
        public decimal Amount { get; set; }

        [DataType(DataType.Text)]
        public string Message { get; set; } = string.Empty;

        public string DonorId { get; set; } = string.Empty;
        public virtual ApplicationUser? Donor { get; set; }

        public long FundraiserId { get; set; }
        public virtual Fundraiser? Fundraiser { get; set; }
    }
}