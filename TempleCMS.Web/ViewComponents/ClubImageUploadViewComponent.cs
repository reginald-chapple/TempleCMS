using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ClubImageUploadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Club club)
        {
            return View(new ClubImageEditModel
            {
                Id = club.Id,
                Image = club.Image
            });
        }
    }
}