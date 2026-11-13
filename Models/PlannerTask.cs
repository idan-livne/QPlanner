namespace QPlanner.Models
{
    public class PlannerTask
    {
        public string Key { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Team { get; set; } = "";
        public string Quarter { get; set; } = "";
        public string Owner { get; set; } = "";
        public string Status { get; set; } = "Not started";
        public string Priority { get; set; } = "Medium";
        public int StartSprint { get; set; }
        public int EndSprint { get; set; }

        public bool IsDone => Status == "Done";

        public int Weeks => (EndSprint - StartSprint + 1) * 2;

        public string SprintRange => StartSprint == EndSprint ? $"S{StartSprint}" : $"S{StartSprint} – S{EndSprint}";

        public string StatusClass => "status-" + Status.ToLower().Replace(" ", "-");

        public string PriorityClass => "priority-" + Priority.ToLower();
    }
}
