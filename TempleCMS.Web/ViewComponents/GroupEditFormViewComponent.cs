using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupEditFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Group group)
        {
            return View(new GroupEditModel
            {
                Id = group.Id,
                Name = group.Name,
                IsOpen = group.IsOpen
            });
        }
    }
}