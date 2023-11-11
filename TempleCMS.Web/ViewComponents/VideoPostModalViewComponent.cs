using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class VideoPostModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long clubId)
        {
            return View(new VideoPostInputModel
            {
                ClubId = clubId
            });
        }
    }
}