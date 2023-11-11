using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Models
{
<<<<<<<< HEAD:TempleCMS.Web/Models/ClubMissionEditModel.cs
    public class ClubGuidelinesEditModel
    {
        public ClubGuidelinesEditModel() {}
========
    public class ChurchMissionEditModel
    {
        public ChurchMissionEditModel() {}
>>>>>>>> parent of 5530561 (massive changes):TempleCMS.Web/Models/ChurchMissionEditModel.cs
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Guidelines { get; set; } = string.Empty;
    }
}
