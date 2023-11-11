using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchMissionFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Church church)
        {
            return View(new ChurchMissionEditModel
            {
                Id = church.Id,
                Mission = HttpUtility.HtmlDecode(church.Mission)
            });
        }
    }
}