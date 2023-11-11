using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchBackgroundFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Church church)
        {
            return View(new ChurchBackgroundEditModel
            {
                Id = church.Id,
                Background = HttpUtility.HtmlDecode(church.Background)
            });
        }
    }
}