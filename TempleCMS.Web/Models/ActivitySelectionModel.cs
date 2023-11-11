namespace TempleCMS.Web.Models
{
    public class ActivitySelectionModel
    {
        public long ActivityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
    }
}