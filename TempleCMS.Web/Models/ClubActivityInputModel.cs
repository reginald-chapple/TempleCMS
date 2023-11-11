namespace TempleCMS.Web.Models
{
    public class ClubActivityInputModel
    {
        public long ClubId { get; set; }

        public List<ActivitySelectionModel> ActivitySelections { get; set; } = new ();
    }
}