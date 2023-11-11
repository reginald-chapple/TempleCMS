using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
<<<<<<<< HEAD:TempleCMS.Web/Models/ClubAboutEditModel.cs
    public class ClubAboutEditModel
    {
        public ClubAboutEditModel() {}
========
    public class ChurchMessageEditModel
    {
        public ChurchMessageEditModel() {}
>>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/Models/ChurchMessageEditModel.cs
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Message { get; set; } = string.Empty;
    }
}
