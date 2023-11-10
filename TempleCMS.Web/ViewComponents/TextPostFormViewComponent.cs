using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class TextPostFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long groupId)
        {
            return View(new TextPostInputModel
            {
                GroupId = groupId
            });
        }
    }
}