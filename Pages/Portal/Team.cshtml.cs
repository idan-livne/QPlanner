using QPlanner.Data;
using QPlanner.Models;

namespace QPlanner.Pages.Portal
{
    public class TeamModel : PortalPageModel
    {
        public Team Team { get; set; } = new Team();
        public List<TeamMember> Members { get; set; } = new List<TeamMember>();
        public List<PlannerTask> Tasks { get; set; } = new List<PlannerTask>();
        public Sprint? CurrentSprint { get; set; }

        public void OnGet()
        {
            Team = MockData.FindTeam(TeamName);
            Members = MockData.MembersOf(TeamName);
            Tasks = MockData.TasksFor(TeamName, MockData.CurrentQuarter);
            CurrentSprint = MockData.SprintsFor(MockData.CurrentQuarter).FirstOrDefault(s => s.IsCurrent);
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
