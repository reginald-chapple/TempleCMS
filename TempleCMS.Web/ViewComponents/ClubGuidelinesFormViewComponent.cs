using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ClubGuidelinesFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Club club)
        {
            return View(new ClubGuidelinesEditModel
            {
                Id = club.Id,
                Guidelines = HttpUtility.HtmlDecode(club.Guidelines)
            });
        }
    }
}