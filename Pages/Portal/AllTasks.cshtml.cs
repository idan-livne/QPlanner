using QPlanner.Data;
using QPlanner.Models;

namespace QPlanner.Pages.Portal
{
    public class AllTasksModel : PortalPageModel
    {
        public List<PlannerTask> OpenTasks { get; set; } = new List<PlannerTask>();

        public List<string> Quarters { get; } = new List<string> { MockData.CurrentQuarter, MockData.NextQuarter };

        public void OnGet()
        {
            OpenTasks = MockData.OpenTasksFor(TeamName);
        }

        public List<PlannerTask> OpenTasksIn(string quarter)
        {
            return OpenTasks.Where(t => t.Quarter == quarter).OrderBy(t => t.StartSprint).ToList();
        }
    }
}
