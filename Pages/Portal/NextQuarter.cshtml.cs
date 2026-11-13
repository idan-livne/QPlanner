using QPlanner.Data;

namespace QPlanner.Pages.Portal
{
    public class NextQuarterModel : QuarterPageModel
    {
        public void OnGet()
        {
            LoadQuarter(MockData.NextQuarter, "/Portal/NextQuarter");
        }
    }
}
