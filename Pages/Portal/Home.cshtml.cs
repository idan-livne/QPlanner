using QPlanner.Data;
using QPlanner.Models;

namespace QPlanner.Pages.Portal
{
    public class HomeModel : PortalPageModel
    {
        public List<PlannerTask> Tasks { get; set; } = new List<PlannerTask>();
        public List<TeamMember> Members { get; set; } = new List<TeamMember>();
        public Sprint? CurrentSprint { get; set; }
        public int SprintCount { get; set; }
        public int NextQuarterCount { get; set; }

        public List<PlannerTask> BlockedTasks => Tasks.Where(t => t.Status == "Blocked").ToList();

        public void OnGet()
        {
            Tasks = MockData.TasksFor(TeamName, MockData.CurrentQuarter);
            Members = MockData.MembersOf(TeamName);
            NextQuarterCount = MockData.TasksFor(TeamName, MockData.NextQuarter).Count;

            var sprints = MockData.SprintsFor(MockData.CurrentQuarter);
            SprintCount = sprints.Count;
            CurrentSprint = sprints.FirstOrDefault(s => s.IsCurrent);
        }

        public int CountStatus(string status)
        {
            return Tasks.Count(t => t.Status == status);
        }

        public PlannerTask? CurrentTaskOf(string member)
        {
            if (CurrentSprint == null)
            {
                return null;
            }
            int sprint = CurrentSprint.Number;
            return Tasks.FirstOrDefault(t => t.Owner == member && sprint >= t.StartSprint && sprint <= t.EndSprint);
        }
    }
}
