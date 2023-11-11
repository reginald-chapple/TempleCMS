using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public enum Branch
    {
        [Description("Catholic")]
        Catholic,
        [Description("Eastern Orthodox")]
        EasternOrthodox,
        [Description("Oriental Orthodox")]
        OrientalOrthodox,
        [Description("Protestant")]
        Protestant,
        [Description("Unitarian")]
        Unitarian,
        [Description("Non-Denominational")]
        NonDenominational
    }
}