using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchServiceFormViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(long churchId)
        {
            return View(new Service
            {
                ChurchId = churchId
            });
        }
    }
}