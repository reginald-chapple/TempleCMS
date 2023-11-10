using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
    public class GroupMissionEditModel
    {
        public GroupMissionEditModel() {}
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Mission { get; set; } = string.Empty;
    }
}
