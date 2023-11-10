using System.ComponentModel.DataAnnotations;

namespace TempleCMS.Web.Domain
{
    public class Campaign : Entity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Goal { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Problem { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Beneficiaries { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Importance { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string Solution { get; set; } = string.Empty;

        public ProgressStatus Status { get; set; } = ProgressStatus.Draft;

        public DateTime? Deadline { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Manager { get; set; } = string.Empty;

        public long CauseId { get; set; }
        public virtual Cause? Cause { get; set; }

        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }

        public int DaysPassed()
        {
            if (PublishDate.HasValue)
            {
                return (DateTime.Now.Date - PublishDate.Value.Date).Days;
            }

            return 0;
        }
    }
}