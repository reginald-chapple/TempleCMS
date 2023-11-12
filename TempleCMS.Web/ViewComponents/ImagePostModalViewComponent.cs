using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ImagePostModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long churchId)
        {
            return View(new ImagePostInputModel
            {
                ChurchId = churchId
            });
        }
    }
}