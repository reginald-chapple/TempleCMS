using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
    public class ClubAboutEditModel
    {
        public ClubAboutEditModel() {}
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string About { get; set; } = string.Empty;
    }
}
