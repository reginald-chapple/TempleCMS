namespace TempleCMS.Web.Models
{
    public class GroupValueInputModel
    {
        public long GroupId { get; set; }

        public List<ValueSelectionModel> ValueSelections { get; set; } = new ();
    }
}