using System.ComponentModel.DataAnnotations;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Infrastructure.Validation;

namespace TempleCMS.Web.Models
{
    public class ChurchEditModel
    {
        public ChurchEditModel() {}

        public long Id { get; set; }

        [StringLength(75, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Denomination")]
        public long DenominationId { get; set; }
    }
}