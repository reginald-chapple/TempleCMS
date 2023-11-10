using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class VideoPostModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long groupId)
        {
            return View(new VideoPostInputModel
            {
                GroupId = groupId
            });
        }
    }
}