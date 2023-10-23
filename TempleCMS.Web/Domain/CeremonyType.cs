using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public enum CeremonyType
    {
        [Description("Anointing of the Sick")]
        AnointingOfTheSick,
        [Description("Baptism")]
        Baptism,
        [Description("Confirmation")] 
        Confirmation, 
        [Description("Eucharist")]
        Eucharist,
        [Description("Funeral")]
        Funeral,
        [Description("Marriage")]
        Marriage,
        [Description("Ordination")]
        Ordination,
        [Description("Reconciliation")]
        Reconciliation
    }
}