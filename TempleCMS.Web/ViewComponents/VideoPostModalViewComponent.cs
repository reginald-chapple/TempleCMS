using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class VideoPostModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long churchId)
        {
            return View(new VideoPostInputModel
            {
                ChurchId = churchId
            });
        }
    }
}