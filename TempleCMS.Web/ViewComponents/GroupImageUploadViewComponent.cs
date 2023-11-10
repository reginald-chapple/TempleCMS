using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupImageUploadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Group group)
        {
            return View(new GroupImageEditModel
            {
                Id = group.Id,
                Image = group.Image
            });
        }
    }
}