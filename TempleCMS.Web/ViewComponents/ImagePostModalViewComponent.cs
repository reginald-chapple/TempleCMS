using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ImagePostModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long clubId)
        {
            return View(new ImagePostInputModel
            {
                ClubId = clubId
            });
        }
    }
}