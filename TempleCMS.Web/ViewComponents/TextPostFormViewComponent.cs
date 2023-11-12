using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class TextPostFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long churchId)
        {
            return View(new TextPostInputModel
            {
                ChurchId = churchId
            });
        }
    }
}