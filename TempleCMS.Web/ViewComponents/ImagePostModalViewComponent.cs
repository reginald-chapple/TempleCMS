using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ImagePostModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long groupId)
        {
            return View(new ImagePostInputModel
            {
                GroupId = groupId
            });
        }
    }
}