using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupMissionFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Group group)
        {
            return View(new GroupMissionEditModel
            {
                Id = group.Id,
                Mission = HttpUtility.HtmlDecode(group.Mission)
            });
        }
    }
}