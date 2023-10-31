using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchMessageFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Church church)
        {
            return View(new ChurchMessageEditModel
            {
                Id = church.Id,
                Message = HttpUtility.HtmlDecode(church.Message)
            });
        }
    }
}