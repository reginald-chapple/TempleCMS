using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
    public class ChurchMessageEditModel
    {
        public ChurchMessageEditModel() {}
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Message { get; set; } = string.Empty;
    }
}
