using System.ComponentModel;

namespace TempleCMS.Web.Domain
{
    public enum AccountType
    {
        [Description("Leader")]
        Leader,
        [Description("Clergy")]
        Clergy,
        [Description("Member")]
        Member
    }
}