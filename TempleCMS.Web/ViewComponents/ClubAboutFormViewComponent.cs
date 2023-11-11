using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ClubAboutFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Club club)
        {
            return View(new ClubAboutEditModel
            {
                Id = club.Id,
                About = HttpUtility.HtmlDecode(club.About)
            });
        }
    }
}