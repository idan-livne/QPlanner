namespace QPlanner.Models
{
    public class TeamMember
    {
        public string Name { get; set; } = "";
        public string Role { get; set; } = "";
        public string Email { get; set; } = "";
        public string Team { get; set; } = "";

        public string Initials => string.Concat(Name.Split(' ').Select(part => part[0]));
    }
}
