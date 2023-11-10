using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
    public class GroupAboutEditModel
    {
        public GroupAboutEditModel() {}
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string About { get; set; } = string.Empty;
    }
}
