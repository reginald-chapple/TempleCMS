using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchImageUploadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Church church)
        {
            return View(new ChurchImageEditModel
            {
                Id = church.Id,
                Image = church.Image
            });
        }
    }
}