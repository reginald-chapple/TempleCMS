using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupAboutFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Group group)
        {
            return View(new GroupAboutEditModel
            {
                Id = group.Id,
                About = HttpUtility.HtmlDecode(group.About)
            });
        }
    }
}