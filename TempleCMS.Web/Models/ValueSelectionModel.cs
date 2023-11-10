namespace TempleCMS.Web.Models
{
    public class ValueSelectionModel
    {
        public long ValueId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
    }
}