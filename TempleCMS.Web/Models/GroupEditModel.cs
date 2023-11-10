using System.ComponentModel;

namespace TempleCMS.Web.Models
{
    public class GroupEditModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DisplayName("Open")]
        public bool IsOpen { get; set; }
    }
}