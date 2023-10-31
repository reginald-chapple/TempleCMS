using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
    public class ChurchMissionEditModel
    {
        public ChurchMissionEditModel() {}
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Mission { get; set; } = string.Empty;
    }
}
