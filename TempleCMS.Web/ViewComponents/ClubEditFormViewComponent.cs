using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ClubEditFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Club club)
        {
            return View(new ClubEditModel
            {
                Id = club.Id,
                Name = club.Name,
                IsOpen = club.IsOpen
            });
        }
    }
}