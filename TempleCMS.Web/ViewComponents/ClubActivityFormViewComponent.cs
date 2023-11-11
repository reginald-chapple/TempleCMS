using System.Web;
using Microsoft.AspNetCore.Mvc;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.ViewComponents
{
    public class ClubActivityFormViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ClubActivityFormViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(Club club)
        {
            return View(new ClubActivityInputModel
            {
                ClubId = club.Id,
                ActivitySelections = PopulateSelectedValue(club)
            });
        }

        private List<ActivitySelectionModel> PopulateSelectedValue(Club club)
        {
            var allActivities = _context.Activities.ToList();
            var clubActivity = new HashSet<long>(club.Activities.Select(g => g.ActivityId));
            var viewModel = new List<ActivitySelectionModel>();

            foreach (var activity in allActivities)
            {
                viewModel.Add(new ActivitySelectionModel
                {
                    ActivityId = activity.Id,
                    Name = activity.Name,
                    IsChecked = clubActivity.Contains(activity.Id)
                });
            }
            return viewModel;
        }
    }
}