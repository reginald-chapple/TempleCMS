using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class TextPostFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long clubId)
        {
            return View(new TextPostInputModel
            {
                ClubId = clubId
            });
        }
    }
}