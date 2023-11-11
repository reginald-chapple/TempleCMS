using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
    public class ChurchBackgroundEditModel
    {
        public ChurchBackgroundEditModel() {}
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Background { get; set; } = string.Empty;
    }
}
