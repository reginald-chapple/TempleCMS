using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
    public class ClubGuidelinesEditModel
    {
        public ClubGuidelinesEditModel() {}
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Guidelines { get; set; } = string.Empty;
    }
}
