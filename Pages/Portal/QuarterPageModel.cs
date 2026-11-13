using Microsoft.AspNetCore.Mvc;
using QPlanner.Data;
using QPlanner.Models;

namespace QPlanner.Pages.Portal
{
    // Shared code for the Current Q and Next Q pages.
    public class QuarterPageModel : PortalPageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "list";

        public string PageName { get; set; } = "";
        public string Quarter { get; set; } = "";
        public List<PlannerTask> Tasks { get; set; } = new List<PlannerTask>();
        public List<TeamMember> Members { get; set; } = new List<TeamMember>();
        public List<Sprint> Sprints { get; set; } = new List<Sprint>();

        public bool ShowPlan => Tab == "plan";

        public int DoneCount => Tasks.Count(t => t.IsDone);

        public int TotalWeeks => Tasks.Sum(t => t.Weeks);

        public int WeeksLeft => Tasks.Where(t => !t.IsDone).Sum(t => t.Weeks);

        protected void LoadQuarter(string quarter, string pageName)
        {
            Quarter = quarter;
            PageName = pageName;
            Tasks = MockData.TasksFor(TeamName, quarter);
            Members = MockData.MembersOf(TeamName);
            Sprints = MockData.SprintsFor(quarter);
        }

        public PlannerTask? TaskAt(string member, int sprint)
        {
            return Tasks.FirstOrDefault(t => t.Owner == member && sprint >= t.StartSprint && sprint <= t.EndSprint);
        }
    }
}
