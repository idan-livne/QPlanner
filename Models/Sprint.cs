namespace QPlanner.Models
{
    public class Sprint
    {
        public int Number { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Name => "S" + Number;

        public string Dates => $"{Start:d/M} – {End:d/M}";

        public bool IsCurrent => DateTime.Today >= Start && DateTime.Today <= End;
    }
}
