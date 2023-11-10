using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class GroupValueFormViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GroupValueFormViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(Group group)
        {
            return View(new GroupValueInputModel
            {
                GroupId = group.Id,
                ValueSelections = PopulateSelectedValue(group)
            });
        }

        private List<ValueSelectionModel> PopulateSelectedValue(Group group)
        {
            var allValues = _context.Values.ToList();
            var groupValues = new HashSet<long>(group.Values.Select(g => g.ValueId));
            var viewModel = new List<ValueSelectionModel>();

            foreach (var value in allValues)
            {
                viewModel.Add(new ValueSelectionModel
                {
                    ValueId = value.Id,
                    Name = value.Name,
                    IsChecked = groupValues.Contains(value.Id)
                });
            }
            return viewModel;
        }
    }
}