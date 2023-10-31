using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ChurchEditFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Church church)
        {
            return View(new ChurchEditModel
            {
                Id = church.Id,
                Name = church.Name,
                DenominationId = church.DenominationId
            });
        }
    }
}